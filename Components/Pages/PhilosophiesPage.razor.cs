using Lab;

namespace BlazorApp.Components.Pages
{
	public partial class PhilosophiesPage : EntityBlazorPage<Philosophy>
	{
		PhilosophyData m_philosophyData = new();

		protected override async Task CreateEntity()
		{
			await View.CreateEntityAsync(new Philosophy()
			{
				PhilosophyName = m_philosophyData.Name,
			});
			await FetchData();
		}

		private class PhilosophyData
		{
			public string Name = "";
		}
	}
}