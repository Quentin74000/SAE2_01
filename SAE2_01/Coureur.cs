using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Media.Animation;

namespace SAE2_01
{
    public enum GenreCoureur { Neutre = 'N', Homme = 'H', Femme = 'F' };
    public class Coureur : ICloneable
    {
        private int num_coureur;
        private string code_club;
        private string num_federation;
        private string nom_coureur;
        private string lien_photo;
        private string prenom_coureur;
        private string ville_coureur;
        private string portable;
        private string sexe;
        private string num_licence;


        public Coureur(string code_club, string num_federation, string nom_coureur, string lien_photo, string prenom_coureur, string ville_coureur, string portable, string sexe, string num_licence)
        {
            this.Code_club = code_club;
            this.Num_federation = num_federation;
            this.Nom_coureur = nom_coureur;
            this.Lien_photo = lien_photo;
            this.Prenom_coureur = prenom_coureur;
            this.Ville_coureur = ville_coureur;
            this.Portable = portable;
            this.Sexe = sexe;
            this.Num_licence = num_licence;
        }
        public Coureur(int numcoureur, string code_club, string num_federation, string nom_coureur, string lien_photo, string prenom_coureur, string ville_coureur, string portable, string sexe, string num_licence)
            : this(code_club, num_federation, nom_coureur, lien_photo, prenom_coureur, ville_coureur, portable, sexe, num_licence)
        {
            this.Num_coureur = numcoureur;
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

        public string Code_club
        {
            get
            {
                return code_club;
            }

            set
            {
                if (value.Length > 2) { throw new ArgumentOutOfRangeException("Le code du club doit être composé de deux caractères maximum"); };
                code_club = value;
            }
        }

        public string Num_federation
        {
            get
            {
                return num_federation;
            }

            set
            {
                if (value.Length > 3) { throw new ArgumentOutOfRangeException("Le numéro de la fédération doit être composé de trois caractères maximum"); };
                num_federation = value;
            }
        }

        public string Nom_coureur
        {
            get
            {
                return nom_coureur;
            }

            set
            {
                if (value.Length>50) { throw new ArgumentOutOfRangeException("Le nom du coureur ne doit pas dépaser les 50 caractères"); };
                nom_coureur = value;
            }
        }

        public string Lien_photo
        {
            get
            {
                return lien_photo;
            }

            set
            {
                if (value.Length > 100) { throw new ArgumentOutOfRangeException("Le lien de la photo ne doit pas dépaser les 100 caractères"); };
                lien_photo = value;
            }
        }

        public string Prenom_coureur
        {
            get
            {
                return prenom_coureur;
            }

            set
            {
                if (value.Length > 50) { throw new ArgumentOutOfRangeException("Le prénom du coureur ne doit pas dépaser les 50 caractères"); };
                prenom_coureur = value;
            }
        }

        public string Ville_coureur
        {
            get
            {
                return ville_coureur;
            }

            set
            {
                if ( value.Length > 50) { throw new ArgumentOutOfRangeException("Le nom de la ville ne doit pas dépaser les 50 caractères"); };
                ville_coureur = value;
            }
        }

        public string Portable
        {
            get
            {
                return portable;
            }

            set
            {
                if (!Regex.IsMatch(value, "^[0-9]{10}$"))
                    throw new ArgumentException("Le format du tel n'est pas correct. 10 chiffres attendus.");
                portable = value;
            }
        }

        public string Sexe
        {
            get
            {
                return sexe;
            }

            set
            {
                if (value.Length > 1) { throw new ArgumentOutOfRangeException("Le sexe du coureur doit être composé d'un caractère maximum"); };
                sexe = value;
            }
        }

        public string Num_licence
        {
            get
            {
                return this.num_licence;
            }

            set
            {
                if (value.Length > 10) { throw new ArgumentOutOfRangeException("Le numéro de licence doit être composé de deux caractères maximum"); };
                this.num_licence = value;
            }
        }

        public object Clone()
        {
            return new Coureur(this.num_coureur, this.code_club, this.num_federation, this.nom_coureur, this.lien_photo, this.prenom_coureur, this.ville_coureur, this.portable, this.sexe, this.num_licence);
        }

        public override string? ToString()
        {
            return Nom_coureur + " " + Prenom_coureur + " " + Portable + " " + Num_federation;
        }

    }
}
