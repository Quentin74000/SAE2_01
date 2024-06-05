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
    /// Logique d'interaction pour Inscription_course.xaml
    /// </summary>
    public partial class Inscription_course : Window
    {
        public Inscription_course()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void But_Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            this.Hide();
            mainwindow.ShowDialog();
        }

        private void But_Visualiser_Course_Click(object sender, RoutedEventArgs e)
        {
            Visualiser_Course visualiser_course = new Visualiser_Course();
            this.Hide();
            visualiser_course.ShowDialog();
        }

        private void But_Visualiser_Coureur_Click(object sender, RoutedEventArgs e)
        {
            Visualiser_Coureur visualiser_coureur = new Visualiser_Coureur();
            this.Hide();
            visualiser_coureur.ShowDialog();
        }
    }
}
