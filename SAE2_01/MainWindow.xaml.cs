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
    }
}
