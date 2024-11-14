using Controller;
using Lab;
using View;

namespace BlazorApp.Controller
{
	public class PPCsController : EntityController<PhilosopherPhilosophyConnection>
	{
		public PPCsController(PhilosophersDbStorage model, EntityView<PhilosopherPhilosophyConnection> view) : base(model,
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

			if (type == typeof(Philosophy))
			{
				Philosophy? philosophy = m_model.GetPhilosophy(id);
				m_view.ReferencedEntities[typeof(Philosophy)] = philosophy;
				return;
			}
		}

		protected override void OnEntityDeleted(int id)
		{
			PhilosopherPhilosophyConnection? ppc = m_model.GetPpc(id);

			if (ppc != null)
			{
				m_view.EntityDeleteTask = m_model.RemovePpcAsync(ppc);
			}
		}

		protected override void OnEntityCreated(PhilosopherPhilosophyConnection obj)
		{
			m_view.EntityCreateTask = m_model.AddPpcAsync(obj);
		}


		protected override void OnEntityRequested()
		{
			m_view.EntityRequestTask = m_model.GetPpcsAsync();
		}
	}
}