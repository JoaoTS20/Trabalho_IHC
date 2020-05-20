using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Pets_At_First_Sight
{
    /// <summary>
    /// Interaction logic for Inicio.xaml
    /// </summary>
    /// 

    public partial class Inicio : Page
    {
        public Inicio()
        {
            
            InitializeComponent();
            
            //Dados_Originais();
            Posts.ItemsSource = Container.animais;
            CollectionViewSource.GetDefaultView(Container.animais).Refresh();

            //refresh();

        }


        //Função de pesquisar de exemplo de como tem de filtrar neste caso o pesquisa procurar ao fazer enter. se não tiver testo mostra normal após testo
        //É assim que iremos filtrar no perfil
        //No Favoritos é um boolean que irá ser adicionado ao coisos se verdade está preto e na lista se não branco e não na lista.
        //Criar Post é só copiar Dados_Originais basicamente mas o texto e url(utilizar apenas imagens da pasta) é retirado da text box dos paramentros.
        //Filtrar será algo do género também
        //Boa NoITE
        //PARA A LOJA É A MESMA LÓGICA E APENAS OUTRA CLASSE
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            List<ANIMAL> Filtrar = new List<ANIMAL>();

            if (e.Key == Key.Return && pesquisa.Text!="")
            {
                
                foreach (ANIMAL m in Container.animais)
                {
                    if(m.User_Name.Equals(pesquisa.Text))
                    {
                        Filtrar.Add(m);
                    }
                }
                Posts.ItemsSource = Filtrar;

            }
            else if (e.Key == Key.Return && pesquisa.Text==""){
                Posts.ItemsSource = null;
                Posts.ItemsSource = Container.animais;

            }
        }
        private void Dados_Originais()
        {
            String s = "Imagens\\"; //Tem de ser assim
            //Façam o mesmo depois para escrever o meses na idade
            Container.animais.Add(new ANIMAL() { Nome = "Cãoasdasd", Idade = "5 meses", Genero = "Masculino", Raca = "Cão", Url_Image = s + "stock_dog1.jpg", User_Name = "Filipa" });
            Container.animais.Add(new ANIMAL() { Nome = "Princesa", Idade = "10 anos", Genero = "Feminino", Raca = "Gato", Url_Image = s + "stock_gato1.jpg", User_Name = "Anthony Pereira" });
            Container.animais.Add(new ANIMAL() { Nome = "Piu", Idade = "5 anos", Genero = "Feminino", Raca = "Cão", Url_Image = s + "stock_dog1.jpg", User_Name = "Anthony Pereira" });
            Container.animais.Add(new ANIMAL() { Nome = "No Name", Idade = "7 anos", Genero = "Feminino", Raca = "Gato", Url_Image = s + "stock_gato1.jpg", User_Name = "Alexandra" });
            Container.animais.Add(new ANIMAL() { Nome = "Stock#1", Idade = "8 meses", Genero = "Masculino", Raca = "Cão", Url_Image = s + "stock_dog1.jpg", User_Name = "João" });
            Posts.ItemsSource = Container.animais;
        }
        bool taFav = false;
        bool taDoa = false;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InicioFiltros inicioFiltros = new InicioFiltros();
            NavigationService.Navigate(inicioFiltros);
        }

        private void Adopt(object sender, RoutedEventArgs e)
        {
            //mesma coisa
        }
        private void Fave(object sender, RoutedEventArgs e)
        {
            if (!taFav) //teste
            {
                //Buscar labels e tal
                String s = "Imagens\\";
                Container.favoritos.Add(new ANIMAL() { Nome = "Cãoasdasd", Idade = "5 meses", Genero = "Masculino", Raca = "Cão", Url_Image = s + "stock_dog1.jpg", User_Name = "Filipa" });
                new Favoritos();
                //Mudar imagem source
                taFav = true;
            }

            else if(taFav)
            {
                Container.favoritos.Clear(); //testar
                new Favoritos();
                //Mudar imagem source
                taFav = false;

            }
        }


        }

    }

