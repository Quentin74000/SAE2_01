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

        private void But_Visualiser_Course_Click(object sender, RoutedEventArgs e)
        {
            Visualiser_Course visualiser = new Visualiser_Course();
            visualiser.ShowDialog();
        }

        private void But_inscrire_Click(object sender, RoutedEventArgs e)
        {
            Inscription_course inscription = new Inscription_course();
            inscription.ShowDialog();
        }

        private void But_Ajouter_Nouveau_Coureur_Click(object sender, RoutedEventArgs e)
        {
            FicheInscription ficheinscription = new FicheInscription();
            ficheinscription.ShowDialog();
        }
    }
}
