using Lab;

namespace BlazorApp.Components.Pages
{
	public partial class PCCsPage : EntityBlazorPage<PhilosopherCountryConnection>
	{
		PCCData m_pccData = new();

		private string m_message = "";

		private async void ValidateEntity()
		{
			m_message = "";
			View.UpdateReferencedEntities(m_pccData.PhilosopherId, typeof(Philosopher));
			View.UpdateReferencedEntities(m_pccData.CountryId, typeof(Country));
			Philosopher? philosopher = (Philosopher?)View.ReferencedEntities[typeof(Philosopher)];
			Country? country = (Country?)View.ReferencedEntities[typeof(Country)];
			if (philosopher == null)
			{
				m_message = "Invalid philosopher id!";
			}
			else if (country == null)
			{
				m_message += " Invalid country id!";
			}
			else
			{
				await CreateEntity();
			}
		}

		protected override async Task CreateEntity()
		{
			await View.CreateEntityAsync(new PhilosopherCountryConnection()
			{
				Philosopher = (Philosopher)View.ReferencedEntities[typeof(Philosopher)],
				Country = (Country)View.ReferencedEntities[typeof(Country)],
				PeriodStart = m_pccData.StartDate,
				PeriodEnd = m_pccData.FinishDate
			});
			await FetchData();
		}

		private class PCCData
		{
			public int PhilosopherId;
			public int CountryId;
			public DateOnly StartDate;
			public DateOnly FinishDate;
		}
	}
}