using Controller;
using Lab;
using View;

namespace BlazorApp.Controller
{
	public class WorksController : EntityController<Work>
	{
		public WorksController(PhilosophersDbStorage model, EntityView<Work> view) : base(model, view)
		{
		}

		protected override void OnReferencedEntitiesUpdateRequested(int id, Type type)
		{
			Philosopher? philosopher = m_model.GetPhilosopher(id);
			m_view.ReferencedEntities[typeof(Philosopher)] = philosopher;
		}

		protected override void OnEntityDeleted(int id)
		{
			Work? work = m_model.GetWork(id);
			if (work != null)
			{
				m_view.EntityDeleteTask = m_model.RemoveWorkAsync(work);
			}
		}

		protected override void OnEntityCreated(Work obj)
		{
			m_view.EntityCreateTask = m_model.AddWorkAsync(obj);
		}


		protected override void OnEntityRequested()
		{
			m_view.EntityRequestTask = m_model.GetWorksAsync();
		}
	}
}