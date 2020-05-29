﻿using MaterialDesignThemes.Wpf;
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

            if (e.Key == Key.Return && pesquisa.Text != "")
            {

                foreach (ANIMAL m in Container.animais)
                {
                    if (m.User_Name.Equals(pesquisa.Text) | m.Idade.Equals(pesquisa.Text) | m.Raca.Equals(pesquisa.Text) | m.Genero.Equals(pesquisa.Text))
                    {
                        Filtrar.Add(m);
                    }
                }
                Posts.ItemsSource = Filtrar;

            }
            else if (e.Key == Key.Return && pesquisa.Text == "")
            {
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InicioFiltros inicioFiltros = new InicioFiltros();
            NavigationService.Navigate(inicioFiltros);
        }
        Boolean flagAdo = true;

        private void Adopt(object sender, RoutedEventArgs e)
        {
            Button i = (Button)sender;
            PackIcon b = (PackIcon)i.Content;
            StackPanel s = (StackPanel)i.Parent;
            Grid gr = (Grid)s.Parent;
            Image u = (Image)gr.Children[1];
            String x = u.Source.ToString(); //Não dá o texto de forma correta
            Label r = (Label)gr.Children[2];
            Label n = (Label)gr.Children[3];
            Label y = (Label)gr.Children[4];
            Label g = (Label)gr.Children[5];

            String Nome_Bicho = n.Content.ToString();
            String Idades = y.Content.ToString();
            String Raca = r.Content.ToString();
            String genero = g.Content.ToString();

            if (flagAdo) //teste x== "Icons\\whiteheart.png"
            {
                foreach (ANIMAL zzs in Container.animais)
                {
                    if (zzs.Nome == Nome_Bicho && zzs.Idade == Idades)
                    {
                        Container.adocoes.Add(zzs);

                        b.BeginInit();
                        b.Kind = PackIconKind.Star;
                         b.EndInit();
                        flagAdo = false;
                        new Adocoes();
                        //new Inicio();
                        break;

                    }

                }

            }
            else if (!flagAdo)
            {
                foreach (ANIMAL zzs in Container.animais)
                {
                    if (zzs.Nome == Nome_Bicho && zzs.Idade == Idades)
                    {
                        Container.adocoes.Remove(zzs);

                        b.BeginInit();
                        b.Kind = PackIconKind.StarOutline;
                        b.EndInit();
                        flagAdo = true;
                        new Adocoes();
                        break;

                    }

                }
            }


        }

        Boolean flagFav = true;
        private void Fave(object sender, RoutedEventArgs e)
        {

            //Um pequeno Bug Sai da página o botão deixa de funcionar kinda;
            //Só copiar esta parte para para o adopt (com as devidas diferenças) do Lado Favoritos só copiar a parte da da Flagser Falsa e a definição da Labels e tals

            Button i = (Button)sender;
            PackIcon b = (PackIcon)i.Content;
            StackPanel s = (StackPanel)i.Parent;
            Grid gr = (Grid)s.Parent;
            Image u = (Image)gr.Children[1];
            String x = u.Source.ToString(); //Não dá o texto de forma correta
            Label r = (Label)gr.Children[2];
            Label n = (Label)gr.Children[3];
            Label y = (Label)gr.Children[4];
            Label g = (Label)gr.Children[5];

            String Nome_Bicho = n.Content.ToString();
            String Idades = y.Content.ToString();
            String Raca = r.Content.ToString();
            String genero = g.Content.ToString();
            if (flagFav) //teste x== "Icons\\whiteheart.png"
            {
                foreach (ANIMAL zzs in Container.animais)
                {
                    if (zzs.Nome == Nome_Bicho && zzs.Idade == Idades)
                    {
                        Container.favoritos.Add(zzs);
                        
                        b.BeginInit();
                        b.Kind = PackIconKind.Heart;
                        b.EndInit();
                        flagFav = false;
                        new Favoritos();
                        //new Inicio();
                        break;

                    }

                }

            }
            else if (!flagFav)
            {
                foreach (ANIMAL zzs in Container.animais)
                {
                    if (zzs.Nome == Nome_Bicho && zzs.Idade == Idades)
                    {
                        Container.favoritos.Remove(zzs);
                        
                        b.BeginInit();
                        b.Kind = PackIconKind.HeartOutline;
                        b.EndInit();
                        flagFav = true;
                        new Favoritos();
                        break;

                    }

                }
            }

            
        }

        private void ViewPost(object sender, MouseButtonEventArgs e)
        {

            Grid gr = (Grid)sender;
            Image u = (Image)gr.Children[1];
            Label r = (Label)gr.Children[2];
            Label n = (Label)gr.Children[3];
            Label y = (Label)gr.Children[4];
            Label g = (Label)gr.Children[5];

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
            Post_MaisInfo post_MaisInfo = new Post_MaisInfo();
            NavigationService.Navigate(post_MaisInfo);
        }
    }

    }

