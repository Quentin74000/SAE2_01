using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAE2_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            bool resultat;
            SeConnecter seConnecter = new SeConnecter();
            ConnexionBD dataconnexion = new ConnexionBD();
            do
            {
                seConnecter = new SeConnecter();
                resultat = (bool)seConnecter.ShowDialog();
                if (resultat == true)
                {
                    dataconnexion = new ConnexionBD();
                }
            } while (dataconnexion.Connexion() == false);
            InitializeComponent();

        }
        private void But_inscrire_Click(object sender, RoutedEventArgs e)
        {
            tcGlobal.SelectedItem=Tab_Incription;
        }

        private void tcGlobal_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (tcGlobal.SelectedItem == Tab_Accueil)
            {
                Lab_Nom_Page.Content = string.Empty;
                Lab_Nom_Page.Content = "Accueil";
            }
            else if (tcGlobal.SelectedItem == Tab_Incription)
            {
                Lab_Nom_Page.Content = string.Empty;
                Lab_Nom_Page.Content = "Inscription";
            }
            else if (tcGlobal.SelectedItem == Tab_Visualiser_Coureur)
            {
                Lab_Nom_Page.Content = string.Empty;
                Lab_Nom_Page.Content = "Rechercher un coureur";
            }
            else
            {
                Lab_Nom_Page.Content = string.Empty;
                Lab_Nom_Page.Content = "Rechercher une course";
            }
        }
    }
}
