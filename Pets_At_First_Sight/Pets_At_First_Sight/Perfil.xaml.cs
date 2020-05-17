using System.Windows.Controls;
using System.Windows;

namespace Pets_At_First_Sight
{
    /// <summary>
    /// Interaction logic for Perfil.xaml
    /// </summary>
    public partial class Perfil : Page
    {
        public Perfil()
        {
            InitializeComponent();
        }

        bool check = true;

        private void More_info_button(object sender, System.Windows.RoutedEventArgs e)
        {
            if (check == true)
            {
                InfosRow.Height = new GridLength(150);
                Infos.Height = 100;
                Infos.Visibility = Visibility.Visible;
                check = false;
            } else
            {
                InfosRow.Height = new GridLength(70);
                Infos.Height = 100;
                Infos.Visibility = Visibility.Collapsed;
                check = true;

            }
            
           
           
        }
    }
}
