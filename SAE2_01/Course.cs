using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SAE2_01
{
    public class Course : ICloneable
    {
        private int num_course;
        private string nom_course;
        private float distance;
        private string heure_depart;
        private float prix_inscription;
        
        public Course(int num_course,string nom_course, float distance, string heure_depart, float prix_inscription)
        {
            this.Num_course = num_course;
            this.Distance = distance;
            this.Heure_depart = heure_depart;
            this.Prix_inscription = prix_inscription;
        }
        public int Num_course
        {
            get
            {
                return this.num_course;
            }

            set
            {
                this.num_course = value;
            }
        }

        public float Distance
        {
            get
            {
                return distance;
            }

            set
            {
                distance = value;
            }
        }

        public string Heure_depart
        {
            get
            {
                return heure_depart;
            }

            set
            {
                heure_depart = value;
            }
        }

        public float Prix_inscription
        {
            get
            {
                return this.prix_inscription;
            }

            set
            {
                this.prix_inscription = value;
            }
        }

        public object Clone()
        {
            return new Course(this.num_course,this.nom_course, this.distance, this.heure_depart, this.prix_inscription);
        }

        public override string? ToString()
        {
            return Num_course + " " + Distance + " " + heure_depart + " " + Prix_inscription;
        }

    }
}
