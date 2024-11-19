using Microsoft.AspNetCore.Components;
using View;

namespace BlazorApp.Components.Pages
{
	public abstract class EntityBlazorPage<TEntity> : ComponentBase where TEntity : class
	{
		[Inject] public EntityView<TEntity> View { get; set; }

		protected List<TEntity>? m_entityList;
		protected List<TEntity>? m_displayedEntityList;

		protected int m_currentPage = 1;
		protected int m_pageSize = 5;

		protected bool m_isDecreasePageDisabled;
		protected bool m_isIncreasePageDisabled;

		protected abstract Task CreateEntity();

		protected void UpdateButtonStatus()
		{
			m_isDecreasePageDisabled = m_currentPage <= 1;
			m_isIncreasePageDisabled = m_entityList.Count - (m_currentPage) * m_pageSize <= 0;
		}

		protected void UpdateDisplayList()
		{
			int length = m_entityList.Count - (m_currentPage-1) * m_pageSize;
			m_displayedEntityList = m_entityList.Slice(Math.Max((m_currentPage - 1) * m_pageSize, 0),
				Math.Min(length, m_pageSize));

			UpdateButtonStatus();
		}

		protected async Task FetchData()
		{
			m_entityList = await View.RequestEntitiesAsync();
			UpdateDisplayList();
			StateHasChanged();
		}

		protected override async Task OnInitializedAsync()
		{
			await FetchData();
		}

		protected async Task DeleteEntityAsync(int id)
		{
			await View.DeleteEntityAsync(id);
			await FetchData();
		}

		protected void IncreasePage()
		{
			++m_currentPage;
			UpdateDisplayList();
		}

		protected void DecreasePage()
		{
			--m_currentPage;
			UpdateDisplayList();
		}
	}
}