using Lab;

namespace BlazorApp.Components.Pages
{
	public partial class PPCsPage : EntityBlazorPage<PhilosopherPhilosophyConnection>
	{
		PCCData m_pscData = new();
		private string m_message = "";

		private async void ValidateEntity()
		{
			m_message = "";
			View.UpdateReferencedEntities(m_pscData.PhilosopherId, typeof(Philosopher));
			View.UpdateReferencedEntities(m_pscData.PhilosophyId, typeof(Philosophy));
			Philosopher? philosopher = (Philosopher?)View.ReferencedEntities[typeof(Philosopher)];
			Philosophy? philosophy = (Philosophy?)View.ReferencedEntities[typeof(Philosophy)];
			if (philosopher == null)
			{
				m_message = "Invalid philosopher id!";
			}
			else if (philosophy == null)
			{
				m_message += " Invalid philosophy id!";
			}
			else
			{
				await CreateEntity();
			}
		}

		protected override async Task CreateEntity()
		{
			await View.CreateEntityAsync(new PhilosopherPhilosophyConnection()
			{
				Philosopher = (Philosopher)View.ReferencedEntities[typeof(Philosopher)],
				Philosophy = (Philosophy)View.ReferencedEntities[typeof(Philosophy)],
				PeriodStart = m_pscData.StartDate,
				PeriodEnd = m_pscData.FinishDate
			});
			await FetchData();
		}

		private class PCCData
		{
			public int PhilosopherId;
			public int PhilosophyId;
			public DateOnly StartDate;
			public DateOnly FinishDate;
		}
	}
}