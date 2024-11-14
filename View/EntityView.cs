using Lab;

namespace View
{
	public class EntityView<TEntity> where TEntity : class
	{
		public event Action? EntitiesRequested;
		public event Action<int>? EntityDeleted;
		public event Action<TEntity>? EntityCreated;
		public event Action<int, Type>? ReferencedEntitiesUpdateRequest;

		public Task<List<TEntity>>? EntityRequestTask { get; set; } = null;
		public Task? EntityDeleteTask { get; set; } = null;
		public Task? EntityCreateTask { get; set; } = null;

		public Dictionary<Type, object?> ReferencedEntities { get; } = new();
		public List<TEntity> Entities { get; private set; } = new List<TEntity>();

		public async Task<List<TEntity>> RequestEntitiesAsync()
		{
			EntitiesRequested?.Invoke();
			if (EntityRequestTask == null)
			{
				return Entities;
			}

			Entities = await EntityRequestTask;
			return Entities;
		}

		public async Task CreateEntityAsync(TEntity entity)
		{
			EntityCreated?.Invoke(entity);

			if (EntityCreateTask == null)
			{
				return;
			}

			await EntityCreateTask;
		}

		public async Task DeleteEntityAsync(int id)
		{
			EntityDeleted?.Invoke(id);
			if (EntityDeleteTask == null)
			{
				return;
			}

			await EntityDeleteTask;
		}

		public void UpdateReferencedEntities(int id, Type type)
		{
			ReferencedEntitiesUpdateRequest?.Invoke(id, type);
		}
	}
}