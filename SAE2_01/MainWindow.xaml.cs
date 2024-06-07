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
        private Course courseSelectionnee=null;
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

        private void But_Ajouter_Nouveau_Coureur_Click(object sender, RoutedEventArgs e)
        {
            FicheInscription ficheinscription = new FicheInscription();
            ficheinscription.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void But_Selectionner_course_Click(object sender, RoutedEventArgs e)
        {
            if (Data_Course.SelectedItem != null)
            {
                courseSelectionnee = (Course)Data_Course.SelectedItem;
                Data_Course.IsEnabled = false;
                ApplicationData.nouvelleInscription = new Inscription(courseSelectionnee.Num_course,DateTime.Today);
            }
            else
                MessageBox.Show(this, "Veuillez selectionner une course");
        }

        private void But_Ajouter_Coureur_Click(object sender, RoutedEventArgs e)
        {
            if (Data_Coureurs.SelectedItem != null)
            {
                Coureur coureurSelectionne = (Coureur)Data_Coureurs.SelectedItem;
                Data_Course.IsEnabled = true;
                ApplicationData.nouvelleInscription2 = new Inscription2(ApplicationData.nouvelleInscription.Num_inscription, coureurSelectionne.Num_coureur,TimeOnly.Parse(tbTPS.Text));
            }
            else
                MessageBox.Show(this, "Veuillez selectionner un coureur");

        }
    }
}
