using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
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