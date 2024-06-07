using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE2_01
{
    public class Inscription2 : ICloneable
    {
        private int num_inscription;
        private int num_coureur;
        private TimeOnly temps_prevu;

        public Inscription2() { }
        public Inscription2(int num_inscription, int num_coureur, TimeOnly temps_prevu)
        {
            this.Num_inscription = num_inscription;
            this.Num_coureur = num_coureur;
            this.Temps_prevu = temps_prevu;
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

        public int Num_coureur
        {
            get
            {
                return num_coureur;
            }

            set
            {
                num_coureur = value;
            }
        }

        public TimeOnly Temps_prevu
        {
            get
            {
                return this.temps_prevu;
            }

            set
            {
                this.temps_prevu = value;
            }
        }
        public object Clone()
        {
            return new Inscription2(this.num_inscription, this.num_coureur, this.temps_prevu);
        }

        public override string? ToString()
        {
            return Num_inscription + " " + Num_coureur + " " + Temps_prevu;
        }
    }
}
