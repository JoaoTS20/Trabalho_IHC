using System.Windows.Controls;
using System.Windows;
using System.Collections.Generic;
using System;
using System.Linq;

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

        /*private void More_info_button(object sender, System.Windows.RoutedEventArgs e)
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
            
           
           
        }*/

        String PerfilUsername = Container.utilizador_logado.First().Username.ToString();
        String PerfilNome = Container.utilizador_logado.First().NomePessoa.ToString();
        String PerfilLocalidade = Container.utilizador_logado.First().Localidade.ToString();
        String PerfilEmail = Container.utilizador_logado.First().Localidade.ToString();

        private void Criar_Post_Click(object sender, RoutedEventArgs e)
        {
            Post cursosPage = new Post();
            this.NavigationService.Navigate(cursosPage);
        }


        private List<ANIMAL> MeusPosts() {
            List<ANIMAL> my = new List<ANIMAL>();
            foreach (ANIMAL m in Container.animais)
            {
                MessageBox.Show(nome.Content.ToString());
                if (m.User_Name.Equals(nome.Content.ToString()))
                {
                    my.Add(m);
                }
            }
            return my;
        }

        private void ViewPost(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Grid gr = (Grid)sender;
            Image u = (Image)gr.Children[0];
            Label r = (Label)gr.Children[1];
            Label n = (Label)gr.Children[2];
            Label y = (Label)gr.Children[3];
            Label g = (Label)gr.Children[4];

            String Nome_Animal = n.Content.ToString();
            String Idades = y.Content.ToString();
            String Raca = r.Content.ToString();
            String genero = g.Content.ToString();

            foreach (ANIMAL animal in Container.animais)
            {
                if (animal.Nome == Nome_Animal && animal.Idade == Idades && animal.Raca == Raca && animal.Genero == genero)
                {
                    Container.animal_selecionado.Add(animal);
                }
            }
            ViewPost_Perfil post = new ViewPost_Perfil();
            NavigationService.Navigate(post);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Post x = new Post();
            this.NavigationService.Navigate(x);
        }
    }
}
