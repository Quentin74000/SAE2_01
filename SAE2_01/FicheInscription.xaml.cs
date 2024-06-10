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
    /// Logique d'interaction pour FicheInscription.xaml
    /// </summary>
    public partial class FicheInscription : Window
    {
        public FicheInscription()
        {
            InitializeComponent();
        }

        private void butValider_Click(object sender, RoutedEventArgs e)
        {

            bool ok = true;
            foreach (UIElement uie in mainPanel.Children)
            {
                if (uie is TextBox)
                {
                    TextBox txt = (TextBox)uie;
                    txt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }

                if (Validation.GetHasError(uie))
                    ok = false;
            }
            foreach (UIElement uie in panelRadioBouton.Children)
            {
                RadioButton rb = (RadioButton)uie;
                rb.GetBindingExpression(RadioButton.IsCheckedProperty).UpdateSource();
                if (Validation.GetHasError(uie))
                    ok = false;
            }
            if (ok)
            {
                String genre = "N";
                if (rbFemme.IsChecked == true) { genre = "F"; }
                else if (rbHomme.IsChecked == true) { genre = "H"; }
                Coureur nouveauCoureur = new Coureur(cbClub.SelectedItem.ToString().Substring(39, 2), cbFede.SelectedItem.ToString().Substring(39, 3), tbNom.Text, tbPhoto.Text, tbPrenom.Text, tbVille.Text, tbTelephone.Text, genre, tbLicence.Text);
                data.Ajouter_Coureur(nouveauCoureur);
                this.Close();
            }
            else
                MessageBox.Show(this, "Erreur", "Vérifiez vos informations.", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

}
