﻿using System;
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
            InitializeComponent();
        }

        private void But_Visualiser_Course_Click(object sender, RoutedEventArgs e)
        {
            Visualiser_Course visualiser = new Visualiser_Course();
            this.Hide();
            visualiser.ShowDialog();
        }

        private void But_inscrire_Click(object sender, RoutedEventArgs e)
        {
            Inscription_course inscription = new Inscription_course();
            this.Hide();
            inscription.ShowDialog();
        }

        private void But_Visualier_Coureur_Click(object sender, RoutedEventArgs e)
        {
            Visualiser_Coureur visualiser_coureur = new Visualiser_Coureur();
            this.Hide();
            visualiser_coureur.ShowDialog();
        }
    }
}
