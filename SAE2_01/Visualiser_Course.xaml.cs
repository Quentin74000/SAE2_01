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
using System.Windows.Shapes;

namespace SAE2_01
{
    /// <summary>
    /// Logique d'interaction pour Visualiser_Course.xaml
    /// </summary>
    public partial class Visualiser_Course : Window
    {
        public Visualiser_Course()
        {
            InitializeComponent();
        }

        private void But_Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            this.Hide();
            mainwindow.ShowDialog();
        }

        private void But_Inscription_Course_Click(object sender, RoutedEventArgs e)
        {
            Inscription_course inscription = new Inscription_course();
            this.Hide();
            inscription.ShowDialog();
        }

        private void But_Visualiser_Coureur_Click(object sender, RoutedEventArgs e)
        {
            Visualiser_Coureur visualiser_coureur = new Visualiser_Coureur();
            this.Hide();
            visualiser_coureur.ShowDialog();
        }
    }
}
