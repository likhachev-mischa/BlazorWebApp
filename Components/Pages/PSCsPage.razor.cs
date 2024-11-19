using Lab;

namespace BlazorApp.Components.Pages
{
	public partial class PSCsPage : EntityBlazorPage<PhilosopherStudentConnection>
	{
		PSCData m_pscData = new();
		private string m_message = "";

		private async void ValidateEntity()
		{
			m_message = "";
			View.UpdateReferencedEntities(m_pscData.TeacherId, typeof(Philosopher));
			View.UpdateReferencedEntities(m_pscData.StudentId, typeof(Philosopher));
			var list = (Philosopher?[])View.ReferencedEntities[typeof(Philosopher)];
			if (list == null)
			{
				m_message = "Invalid philosopher ids!";
			}
			else if (list[0] == null || list[1] == null)
			{
				m_message = "Invalid philosopher id!";
			}
			else
			{
				await CreateEntity();
			}
		}

		protected override async Task CreateEntity()
		{
			var list = (Philosopher?[])View.ReferencedEntities[typeof(Philosopher)];

			await View.CreateEntityAsync(new PhilosopherStudentConnection()
			{
				Teacher = list[0],
				Student = list[1],
				PeriodStart = m_pscData.StartDate,
				PeriodEnd = m_pscData.FinishDate
			});
			await FetchData();
		}

		private class PSCData
		{
			public int TeacherId;
			public int StudentId;
			public DateOnly StartDate;
			public DateOnly FinishDate;
		}
	}
}