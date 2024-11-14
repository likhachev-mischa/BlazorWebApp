using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Philosopher
    {
        public int PhilosopherId { get; set; }
        public string PhilosopherName { get; set; }

        public DateOnly? PhilosopherDob { get; set; }
        public DateOnly? PhilosopherDod { get; set; }

        //public Philosopher(string name)
        //{
        //    PhilosopherName = name;
        //}

        //public Philosopher(string philosopherName, DateOnly? philosopherDob, DateOnly? philosopherDod)
        //{
        //    PhilosopherName = philosopherName;
        //    PhilosopherDob = philosopherDob;
        //    PhilosopherDod = philosopherDod;
        //}
    }
}
