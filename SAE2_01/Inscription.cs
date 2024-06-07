using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE2_01
{
    public class Inscription : ICloneable
    {
        private int num_inscription;
        private int num_course;
        private DateTime date_inscription;
        public Inscription() { }
        public Inscription(int num_course, DateTime date_inscription)
        {
            this.Num_course = num_course;
            this.Date_inscription = date_inscription;
        }
        public Inscription(int num_inscription, int num_course, DateTime date_inscription)
            :this(num_course, date_inscription)
        {
            this.Num_inscription = num_inscription;
        }

        public int Num_inscription
        {
            get
            {
                return num_inscription;
            }

            set
            {
                num_inscription = value;
            }
        }

        public int Num_course
        {
            get
            {
                return num_course;
            }

            set
            {
                num_course = value;
            }
        }

        public DateTime Date_inscription
        {
            get
            {
                return this.date_inscription;
            }

            set
            {
                this.date_inscription = value;
            }
        }
        public object Clone()
        {
            return new Inscription(this.num_inscription, this.num_course, this.date_inscription);
        }

        public override string? ToString()
        {
            return Num_inscription + " " + Num_course + " " + Date_inscription;
        }
    }
}
