

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using Npgsql;

namespace SAE2_01
{

    public class ApplicationData
    {

        private ObservableCollection<Course> lesCourses = new ObservableCollection<Course>();
        private ObservableCollection<Course> lesCoursesSelect = new ObservableCollection<Course>();
        private ObservableCollection<Coureur> lesCoureurs = new ObservableCollection<Coureur>();
        public static NpgsqlConnection connexionBD;
        public static Inscription nouvelleInscription;
        public static Inscription2 nouvelleInscription2;
        private NpgsqlConnection Connexion = connexionBD;   // futur lien à la BD


        public ObservableCollection<Course> LesCourses
        {
            get
            {
                return this.lesCourses;
            }

            set
            {
                this.lesCourses = value;
            }
        }
        public ObservableCollection<Course> LesCoursesSelect
        {
            get
            {
                return this.lesCoursesSelect;
            }

            set
            {
                this.lesCoursesSelect = value;
            }
        }
        public ObservableCollection<Coureur> LesCoureurs
        {
            get
            {
                return this.lesCoureurs;
            }

            set
            {
                this.lesCoureurs = value;
            }
        }



        public ApplicationData()
        {
            Read_Course();
            Read_Coureur();
        }
        public void DeconnexionBD()
        {
            MessageBox.Show("BD déconnectée", "Déconnexion", MessageBoxButton.OK, MessageBoxImage.Information);
            try
            {
                Connexion.Close();
            }
            catch (Exception e)
            { Console.WriteLine("pb à la déconnexion : " + e); }
        }
        public void Ajouter_Coureur(Coureur nouveauCoureur)
        {
            if (nouveauCoureur != null)
            {
                String sql = $"insert into coureur (code_club, num_federation, nom_coureur, lien_photo, prenom_coureur, ville_coureur, potable, sexe, num_licence)"
            + $" values ('{nouveauCoureur.Code_club}','{nouveauCoureur.Num_federation}','{nouveauCoureur.Nom_coureur}'"
            + $",'{nouveauCoureur.Lien_photo}','{nouveauCoureur.Prenom_coureur}', "
            + $"'{nouveauCoureur.Ville_coureur}','{nouveauCoureur.Portable}','{nouveauCoureur.Sexe}','{nouveauCoureur.Num_licence}'); ";
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, Connexion);
                    int nb = cmd.ExecuteNonQuery();
                }
                catch (Exception sqlE)
                {
                    MessageBox.Show("pb de requete : " + sql + "" + sqlE, "Pb requête", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                LesCoureurs.Add(nouveauCoureur);
            }
        }
        public int Read_Course()
        {
            String sql = "SELECT num_course,  nom_course,  distance,  heure_depart, date_depart,  prix_inscription from Course";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Course nouveau = new Course(int.Parse(res["num_course"].ToString()), res["nom_course"].ToString(),
                    float.Parse(res["distance"].ToString()), res["heure_depart"].ToString(), DateTime.Parse(res["date_depart"].ToString()),
                    float.Parse(res["prix_inscription"].ToString()));
                    LesCourses.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int Read_Coureur()
        {
            String sql = "SELECT num_coureur, code_club, num_federation, nom_coureur, lien_photo, prenom_coureur, ville_coureur, potable, sexe, num_licence from Coureur";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Coureur nouveau = new Coureur(int.Parse(res["num_coureur"].ToString()),
                    res["code_club"].ToString(), res["num_federation"].ToString(), res["nom_coureur"].ToString(),
                    res["lien_photo"].ToString(), res["prenom_coureur"].ToString(), res["ville_coureur"].ToString(),
                    res["potable"].ToString(), res["sexe"].ToString(), res["num_licence"].ToString());
                    LesCoureurs.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int SelectCoureur(int id)
        {
            String sql = "SELECT * from course c" +
                "join inscription i on c.num_course=i.num_course" +
                "join inscription2 i2 on i.num_inscription=i2.num_inscription" +
                "where num_coureur = " + id + ";";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Course nouveau = new Course(int.Parse(res["num_course"].ToString()), res["nom_course"].ToString(),
                    float.Parse(res["distance"].ToString()), res["heure_depart"].ToString(), DateTime.Parse(res["date_depart"].ToString()),
                    float.Parse(res["prix_inscription"].ToString()));
                    LesCoursesSelect.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        //public int Create(Course c)
        //{
        //    String sql = $"insert into course (nom,prenom,email,genre,telephone, dateNaissance)"
        //    + $" values ('{c.Nom}','{c.Prenom}','{c.Email}'"
        //    + $",'{(char)c.Genre}','{c.Telephone}', "
        //    + $"'{c.DateNaissance.Year}-{c.DateNaissance.Month}-{c.DateNaissance.Day}'); ";
        //    try
        //    {
        //        NpgsqlCommand cmd = new NpgsqlCommand(sql, Connexion);
        //        int nb = cmd.ExecuteNonQuery();
        //        return nb;
        //        //nb permet de connaître le nb de lignes affectées par un insert, update, delete
        //    }
        //    catch (Exception sqlE)
        //    {
        //        MessageBox.Show("pb de requete : " + sql + "" + sqlE, "Pb requête", MessageBoxButton.OK, MessageBoxImage.Error);
        //        // juste pour le debug : à transformer en MsgBox 
        //        return 0;
        //    }
        //}
        //public int Delete(Client c)
        //{
        //    String sql = $"delete from Client where id = '{c.Id}'";
        //    try
        //    {
        //        NpgsqlCommand cmd = new NpgsqlCommand(sql, Connexion);
        //        int nb = cmd.ExecuteNonQuery();
        //        return nb;
        //        //nb permet de connaître le nb de lignes affectées par un insert, update, delete
        //    }
        //    catch (Exception sqlE)
        //    {
        //        MessageBox.Show("pb de requete : " + sql + "" + sqlE, "Pb requête", MessageBoxButton.OK, MessageBoxImage.Error);
        //        // juste pour le debug : à transformer en MsgBox 
        //        return 0;
        //    }
        //}
        //public int Update(Client c)
        //{
        //    String sql = $"Update client set nom = '{c.Nom}',prenom = '{c.Prenom}'" +
        //        $",email = '{c.Email}',genre = '{(char)c.Genre}',telephone = '{c.Telephone}'" +
        //        $", dateNaissance = '{c.DateNaissance.Year}-{c.DateNaissance.Month}-{c.DateNaissance.Day}' where id = '{c.Id}'";
        //    try
        //    {
        //        NpgsqlCommand cmd = new NpgsqlCommand(sql, Connexion);
        //        int nb = cmd.ExecuteNonQuery();
        //        return nb;
        //        //nb permet de connaître le nb de lignes affectées par un insert, update, delete
        //    }
        //    catch (Exception sqlE)
        //    {
        //        MessageBox.Show("pb de requete : " + sql + "" + sqlE, "Pb requête", MessageBoxButton.OK, MessageBoxImage.Error);
        //        // juste pour le debug : à transformer en MsgBox 
        //        return 0;
        //    }
        //}

    }

}
