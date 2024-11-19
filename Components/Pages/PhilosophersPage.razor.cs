using Lab;
using Microsoft.AspNetCore.Components;
using View;

namespace BlazorApp.Components.Pages
{
	public partial class PhilosophersPage : EntityBlazorPage<Philosopher>
	{
		PhilosopherData m_philosopherData = new();

		private class PhilosopherData
		{
			public string Name = "";
			public DateOnly Dob;
			public DateOnly Dod;
		}

		protected override async Task FetchData()
		{
			if (m_countryFilter == null)
			{
				m_entityList = await View.RequestEntitiesAsync();
			}
			else
			{
				await PCCView.RequestEntitiesAsync();
				m_entityList = PCCView.Entities.Where(c => c.Country.CountryId == m_countryFilter.CountryId)
					.Select(c => c.Philosopher).ToList();
			}

			UpdateDisplayList();
			StateHasChanged();
		}

		protected override async Task OnInitializedAsync()
		{
			m_referencedPhilosophy.EntityList = await PhilosophyView.RequestEntitiesAsync();
			m_referencedCountry.EntityList = await CountryView.RequestEntitiesAsync();
			m_referencedCountryFilter.EntityList = m_referencedCountry.EntityList;
			await base.OnInitializedAsync();
		}

		protected override async Task CreateEntity()
		{
			Philosopher philosopher = new Philosopher()
			{
				PhilosopherName = m_philosopherData.Name,
				PhilosopherDob = m_philosopherData.Dob, PhilosopherDod = m_philosopherData.Dod
			};
			await View.CreateEntityAsync(philosopher);
			if (m_referencedPhilosophy.ChosenEntityId != -1)
			{
				var philosophy = await PhilosophyView.RequestEntityAsync(m_referencedPhilosophy.ChosenEntityId)!;
				if (philosophy != null)
					await PPCView.CreateEntityAsync(new PhilosopherPhilosophyConnection()
					{
						PeriodEnd = m_referencedPhilosophyData.FinishDate,
						PeriodStart = m_referencedPhilosophyData.StartDate, Philosopher = philosopher,
						Philosophy = philosophy
					});
			}

			if (m_referencedCountry.ChosenEntityId != -1)
			{
				var country = await CountryView.RequestEntityAsync(m_referencedCountry.ChosenEntityId)!;
				if (country != null)
					await PCCView.CreateEntityAsync(new PhilosopherCountryConnection()
					{
						PeriodEnd = m_referencedCountryData.FinishDate,
						PeriodStart = m_referencedCountryData.StartDate, Philosopher = philosopher, Country = country
					});
			}

			await FetchData();
		}

		private async void ApplyCountryFilter()
		{
			if (m_referencedCountryFilter.ChosenEntityId == -1)
			{
				m_countryFilter = null;
				await FetchData();
				return;
			}

			var country = await CountryView.RequestEntityAsync(m_referencedCountryFilter.ChosenEntityId)!;

			if (country != null)
				m_countryFilter = country;

			await FetchData();
		}

		//philosophy
		[Inject] public EntityView<PhilosopherPhilosophyConnection> PPCView { get; set; }

		[Inject] public EntityView<Philosophy> PhilosophyView { get; set; }

		private ReferencedEntity<Philosophy> m_referencedPhilosophy = new("philosophy");

		private ReferencedEntityData m_referencedPhilosophyData = new();

		//country
		[Inject] public EntityView<PhilosopherCountryConnection> PCCView { get; set; }

		[Inject] public EntityView<Country> CountryView { get; set; }

		private ReferencedEntity<Country> m_referencedCountry = new("country");

		//filter
		private ReferencedEntity<Country> m_referencedCountryFilter = new("country");
		private Country? m_countryFilter;

		private ReferencedEntityData m_referencedCountryData = new();

		private class ReferencedEntityData
		{
			public DateOnly StartDate;
			public DateOnly FinishDate;
		}
	}
}