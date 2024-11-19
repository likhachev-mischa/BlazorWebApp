namespace Model
{
	public class PhilosopherPhilosophyConnection
    {
        public int PhilosopherPhilosophyConnectionId { get; set; }

        public Philosophy Philosophy { get; set; }
        public Philosopher Philosopher { get; set; }

        public DateOnly? PeriodStart { get; set; }
        public DateOnly? PeriodEnd { get; set; }

          }
}