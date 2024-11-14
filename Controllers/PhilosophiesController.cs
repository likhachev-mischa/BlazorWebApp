using Controller;
using Lab;
using View;

namespace BlazorApp.Controller
{
	public class PhilosophiesController : EntityController<Philosophy>
	{
		public PhilosophiesController(PhilosophersDbStorage model, EntityView<Philosophy> view) : base(model, view)
		{
		}

		protected override void OnEntityDeleted(int id)
		{
			Philosophy? philosophy = m_model.GetPhilosophy(id);
			if (philosophy != null)
			{
				m_view.EntityDeleteTask = m_model.RemovePhilosophyAsync(philosophy);
			}
		}

		protected override void OnEntityCreated(Philosophy obj)
		{
			m_view.EntityCreateTask = m_model.AddPhilosophyAsync(obj);
		}


		protected override void OnEntityRequested()
		{
			m_view.EntityRequestTask = m_model.GetPhilosophiesAsync();
		}
	}
}