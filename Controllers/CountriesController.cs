using Lab;
using View;

namespace Controller
{
	public class CountriesController : EntityController<Country>
	{
		public CountriesController(PhilosophersDbStorage model, EntityView<Country> view) : base(model, view)
		{
		}

		protected override void OnEntityDeleted(int id)
		{
			Country? country = m_model.GetCountry(id);
			if (country != null)
			{
				m_view.EntityDeleteTask = m_model.RemoveCountryAsync(country);
			}
		}

		protected override void OnEntityCreated(Country obj)
		{
			m_view.EntityCreateTask = m_model.AddCountryAsync(obj);
		}

		protected override void OnEntityRequested()
		{
			m_view.EntityRequestTask = m_model.GetCountriesAsync();
		}
	}
}