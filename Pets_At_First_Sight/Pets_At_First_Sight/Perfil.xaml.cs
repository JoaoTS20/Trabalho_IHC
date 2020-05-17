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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           rowtohide.Height = new GridLength(0);
        }

        private void More_info_button(object sender, System.Windows.RoutedEventArgs e)
        {
            Infos.Visibility = Visibility.Visible;
            rowtohide.Height = new GridLength(80);
            Infos.Height = 100;
        }
    }
}
