using System.Windows.Controls;
using System.Windows;
using System.Collections.Generic;

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
            List<ANIMAL> op = MeusPosts();
            My_Posts.ItemsSource = op;
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

        private void Criar_Post_Click(object sender, RoutedEventArgs e)
        {
            Page1 cursosPage = new Page1();
            this.NavigationService.Navigate(cursosPage);
        }


        private List<ANIMAL> MeusPosts() {
            List<ANIMAL> my = new List<ANIMAL>();
            foreach (ANIMAL m in Container.animais)
            {
                if (m.User_Name.Equals(username.Content.ToString()))
                {
                    my.Add(m);
                }
            }
            return my;
        }
    }
}
