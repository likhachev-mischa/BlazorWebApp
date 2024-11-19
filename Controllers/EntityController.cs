using Model;
using View;

namespace Controller
{
	public abstract class EntityController<TEntity> : IDisposable where TEntity : class
	{
		protected readonly PhilosophersDbStorage m_model;
		protected readonly EntityView<TEntity> m_view;

		protected EntityController(PhilosophersDbStorage model, EntityView<TEntity> view)
		{
			m_model = model;
			m_view = view;

			m_view.EntitiesRequested += OnEntitiesRequested;
			m_view.EntityRequested += OnEntityRequested;
			m_view.EntityCreated += OnEntityCreated;
			m_view.EntityDeleted += OnEntityDeleted;
			m_view.ReferencedEntitiesUpdateRequest += OnReferencedEntitiesUpdateRequested;
		}


		protected virtual void OnReferencedEntitiesUpdateRequested(int obj, Type t)
		{
		}
		protected virtual void OnEntityRequested(int id)
		{
		}

		protected abstract void OnEntityDeleted(int id);

		protected abstract void OnEntityCreated(TEntity obj);

		protected abstract void OnEntitiesRequested();

		public void Dispose()
		{
			m_view.EntitiesRequested -= OnEntitiesRequested;
			m_view.EntityRequested -= OnEntityRequested;
			m_view.EntityCreated -= OnEntityCreated;
			m_view.EntityDeleted -= OnEntityDeleted;
			m_view.ReferencedEntitiesUpdateRequest -= OnReferencedEntitiesUpdateRequested;
		}
	}
}