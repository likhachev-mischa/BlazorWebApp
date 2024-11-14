﻿using Controller;
using Lab;
using View;

namespace BlazorApp.Controller
{
	public class PSCsController : EntityController<PhilosopherStudentConnection>
	{
		private Philosopher?[] m_list = new Philosopher[2];
		private int m_flip = 0;

		public PSCsController(PhilosophersDbStorage model, EntityView<PhilosopherStudentConnection> view) : base(model,
			view)
		{
		}

		protected override void OnReferencedEntitiesUpdateRequested(int id, Type type)
		{
			if (type == typeof(Philosopher))
			{
				Philosopher? philosopher = m_model.GetPhilosopher(id);
				m_list[m_flip] = philosopher;
				m_flip = m_flip == 0 ? 1 : 0;
				m_view.ReferencedEntities[typeof(Philosopher)] = m_list;
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

		protected override void OnEntityCreated(PhilosopherStudentConnection obj)
		{
			m_view.EntityCreateTask = m_model.AddPscAsync(obj);
		}


		protected override void OnEntityRequested()
		{
			m_view.EntityRequestTask = m_model.GetPscsAsync();
		}
	}
}