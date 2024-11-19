using Controller;
using Lab;
using View;

namespace BlazorApp.Controller
{
	public class PCCsController : EntityController<PhilosopherCountryConnection>
	{
		public PCCsController(PhilosophersDbStorage model, EntityView<PhilosopherCountryConnection> view) : base(model,
			view)
		{
		}

		protected override void OnReferencedEntitiesUpdateRequested(int id, Type type)
		{
			if (type == typeof(Philosopher))
			{
				Philosopher? philosopher = m_model.GetPhilosopher(id);
				m_view.ReferencedEntities[typeof(Philosopher)] = philosopher;
				return;
			}

			if (type == typeof(Country))
			{
				Country? country = m_model.GetCountry(id);
				m_view.ReferencedEntities[typeof(Country)] = country;
				return;
			}
		}

		protected override void OnEntityDeleted(int id)
		{
			PhilosopherCountryConnection? pcc = m_model.GetPcc(id);

			if (pcc != null)
			{
				m_view.EntityDeleteTask = m_model.RemovePccAsync(pcc);
			}
		}

		protected override void OnEntityCreated(PhilosopherCountryConnection obj)
		{
			m_view.EntityCreateTask = m_model.AddPccAsync(obj);
		}


		protected override void OnEntitiesRequested()
		{
			m_view.EntitiesRequestTask = m_model.GetPccsAsync();
		}
	}
}