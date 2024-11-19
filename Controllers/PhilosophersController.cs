using Lab;
using View;

namespace Controller
{
	public class PhilosophersController : EntityController<Philosopher>
	{
		public PhilosophersController(PhilosophersDbStorage model, EntityView<Philosopher> view) : base(model, view)
		{
		}

		protected override void OnEntityDeleted(int id)
		{
			Philosopher? philosopher = m_model.GetPhilosopher(id);
			if (philosopher != null)
			{
				m_view.EntityDeleteTask = m_model.RemovePhilosopherAsync(philosopher);
			}
		}

		protected override void OnEntityCreated(Philosopher obj)
		{
			m_view.EntityCreateTask = m_model.AddPhilosopherAsync(obj);
		}


		protected override void OnEntitiesRequested()
		{
			m_view.EntitiesRequestTask = m_model.GetPhilosophersAsync();
		}
	}
}