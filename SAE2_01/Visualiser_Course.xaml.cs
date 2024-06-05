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
            mainwindow.ShowDialog();
        }

        private void But_Inscription_Course_Click(object sender, RoutedEventArgs e)
        {
            Inscription_course inscription = new Inscription_course();
            inscription.ShowDialog();
        }
    }
}
