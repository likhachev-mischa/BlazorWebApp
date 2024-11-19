namespace Model
{
	public class Work
    {
        public int WorkId { get; set; }
        public string WorkName { get; set; }
        public DateOnly PublishingDate { get; set; }

        public Philosopher Philosopher { get; set; }
    }
}