namespace Model
{
	public class Philosopher
	{
		public int PhilosopherId { get; set; }
		public string PhilosopherName { get; set; }

		public DateOnly? PhilosopherDob { get; set; }
		public DateOnly? PhilosopherDod { get; set; }
	}
}