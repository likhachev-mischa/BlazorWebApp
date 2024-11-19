using Lab;

namespace BlazorApp.Components.Pages
{
	public partial class CountriesPage : EntityBlazorPage<Country>
	{
		CountryData m_countryData = new();

		private class CountryData
		{
			public string Name = "";
		}

		protected override async Task CreateEntity()
		{
			await View.CreateEntityAsync(new Country()
			{
				CountryName = m_countryData.Name
			});
			await FetchData();
		}
	}
}