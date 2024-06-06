

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
using Npgsql;

namespace SAE2_01
{

    public class ApplicationData
    {

        private ObservableCollection<Course> lesCourses = new ObservableCollection<Course>();
        private ObservableCollection<Coureur> lesCoureurs = new ObservableCollection<Coureur>();
        public static NpgsqlConnection connexionBD;
        private NpgsqlConnection Connexion = connexionBD;   // futur lien à la BD


        public ObservableCollection<Course> LesCourses
        {
            get
            {
                return this.lesCourses;
            }

            set
            {
                this.lesCourses= value;
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
        public int Read_Course()
        {
            String sql = "SELECT num_course,  distance,  heure_depart,  prix_inscription from Course";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Course nouveau = new Course(int.Parse(res["num_course"].ToString()), 
                    float.Parse(res["distance"].ToString()), res["heure_depart"].ToString(), 
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
            String sql = "SELECT * from Coureur";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Coureur nouveau = new Coureur(int.Parse(res["num_coureur"].ToString()), 
                    res["code_club"].ToString(),int.Parse(res["num_federation"].ToString()), res["nom_coureur"].ToString(),
                    res["lien_photo"].ToString(), res["prenom_coureur"].ToString(), res["ville_coureur"].ToString(),
                    res["portable"].ToString(), res["sexe"].ToString(), res["num_licence"].ToString());
                    LesCoureurs.Add(nouveau);
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
