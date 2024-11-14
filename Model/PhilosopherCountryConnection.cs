using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
	public class PhilosopherCountryConnection
    {
        public int PhilosopherCountryConnectionId { get; set; }
        public DateOnly? PeriodStart { get; set; }
        public DateOnly? PeriodEnd { get; set; }

        public Country Country { get; set; }
        public Philosopher Philosopher { get; set; }

           }
}