using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
	public class Work
    {
        public int WorkId { get; set; }
        public string WorkName { get; set; }
        public DateOnly PublishingDate { get; set; }

        public Philosopher Philosopher { get; set; }
    }
}