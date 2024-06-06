using SAE2_01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows;
using System.Windows.Media;

namespace SAE2_01
{
    public class ConnexionBD
    {
        public static string LOGIN, PASSWORD;
        private NpgsqlConnection connexion = null;

        public bool Connexion()
        {
            try
            {
                ApplicationData.connexionBD = new NpgsqlConnection();
                ApplicationData.connexionBD.ConnectionString = "Server=srv-peda-new;" +
                        "port=5433;" +
                        "Database=marathon_beaune;" +
                        "Search Path=marathon_beaune;" +
                        "uid=" + LOGIN + ";" +
                        "password=" + PASSWORD + ";";
                // à compléter dans les "" 
                // @ sert à enlever tout pb avec les caractères 
                ApplicationData.connexionBD.Open();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Problème lors de la connexion ", "Erreur de connexion", MessageBoxButton.OK,MessageBoxImage.Warning) ;
                return false;
                // juste pour le debug : à transformer en MsgBox 
            }

        }
    }
}
