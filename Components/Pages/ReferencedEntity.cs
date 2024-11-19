using View;

namespace BlazorApp.Components.Pages
{
	public class ReferencedEntity<TEntity> where TEntity : class
	{
		public string EntityTypeName { get; set; }
		public int ChosenEntityId { get; set; }
		public IReadOnlyList<TEntity>? EntityList { get; set; }

		private Func<Task<List<TEntity>>> m_entityRequestFunc;
		public ReferencedEntity(string entityTypeName)
		{
			EntityTypeName = entityTypeName;
			ChosenEntityId = -1;
		}
	}
}