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
using System.Windows.Shapes;

namespace SAE2_01
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class SeConnecter : Window
    {
        public string login;
        public string password;
        public SeConnecter()
        {
            InitializeComponent();
        }

        private void butconnexion_Click(object sender, RoutedEventArgs e)
        {
            login = tbLogin.Text;
            password = pbpassword.Password;
        }
    }
}
