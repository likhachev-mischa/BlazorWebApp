using Model;

namespace BlazorApp.Components.Pages
{
	public partial class WorksPage : EntityBlazorPage<Work>
	{
		WorkData m_workData = new();

		private string m_message = "";

		private async void ValidateEntity()
		{
			View.UpdateReferencedEntities(m_workData.PhilosopherId, typeof(Philosopher));
			Philosopher? philosopher = (Philosopher?)View.ReferencedEntities[typeof(Philosopher)];

			if (philosopher == null)
			{
				m_message = "Invalid philosopher id!";
			}
			else
			{
				m_message = "";
				await CreateEntity();
			}
		}

		protected override async Task CreateEntity()
		{
			await View.CreateEntityAsync(new Work()
			{
				WorkName = m_workData.Name,
				PublishingDate = m_workData.PublishingDate,
				Philosopher = (Philosopher)View.ReferencedEntities[typeof(Philosopher)]
			});
			await FetchData();
		}

		private class WorkData
		{
			public string Name = "";
			public DateOnly PublishingDate;
			public int PhilosopherId;
		}
	}
}