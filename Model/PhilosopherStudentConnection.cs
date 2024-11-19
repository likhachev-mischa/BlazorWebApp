namespace Model
{
	public class PhilosopherStudentConnection
    {
        public int PhilosopherStudentConnectionId { get; set; }

        public Philosopher? Teacher { get; set; }

        public Philosopher? Student { get; set; }

        public DateOnly? PeriodStart { get; set; }
        public DateOnly? PeriodEnd { get; set; }
    }
}