﻿using System;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Pets_At_First_Sight
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Post : Page
    {
        public Post()
        {
            InitializeComponent();
            adicionarUser();
            InputImage.Source = new BitmapImage(new Uri("Imagens\\NoImage.jpg", UriKind.Relative));

        }

        public void adicionarUser()
        {
            UserName.Content = Container.utilizador_logado.First().Username.ToString();
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void BtnLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                InputImage.Source = new BitmapImage(fileUri);
                //Console.Write(fileUri);
            }
        }

        private void ButtonSubmeter_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage z = new BitmapImage(new Uri("Imagens\\NoImage.jpg", UriKind.Relative));
            String Especie = EspecieAnimal.Text.ToString();
            String Nome = NomeAnimal.Text.ToString();
            String Idade = IdadeAnimal.Text.ToString();
            String Genero = GeneroAnimal.Text.ToString();
            String _TipoDoador = TipoDoador.Text.ToString();
            String _NomeDoador = UserName.Content.ToString();
            String _Vacinas = Vacinas.Text.ToString();
            String _Chip = Chip.Text.ToString();
            String Testo = PostTexto.Text.ToString();
            String Url_Image_ = InputImage.Source.ToString();
            if (Especie.Length == 0 | Nome.Length == 0 | Idade.Length == 0 | Genero.Length == 0 | _TipoDoador.Length == 0 | _Vacinas.Length == 0 | _Chip.Length == 0 | Testo.Length == 0)
            {
                MessageBox.Show("Prencher todos os campos!!");
            }
            /*if (InputImage.Source == z)
            {
                MessageBoxResult quit = MessageBox.Show("Não adicionou Imagem?", "Adicionar", MessageBoxButton.YesNo);
                switch (quit)
                {
                    case MessageBoxResult.Yes:
                        break;
                    case MessageBoxResult.No:
                        Url_Image_ = "Imagens\\NoImage.jpg";
                       break ;
                }

            }*/
            else
            {
                // String _TipoDoador = TipoDoador.SelectedItem.ToString();
                //String s = "Imagens\\";

                ANIMAL N1 = new ANIMAL()
                {
                    Nome = Nome,
                    Idade = Idade,
                    Genero = Genero,
                    Raca = Especie,
                    Url_Image = Url_Image_,
                    User_Name = _NomeDoador,
                    Mensagem = Testo,
                    Chip = _Chip,
                    Vacinas = _Vacinas,
                    Tipo_Doador = _TipoDoador
                };
                Container.animais.Add(N1);
                MessageBox.Show(N1.ToString());
                new Inicio(); //MILAGRE
                MessageBox.Show("Post Criado");
                Perfil cursosPage = new Perfil();
                this.NavigationService.Navigate(cursosPage);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult quit = MessageBox.Show("O seu post será descartado. Pretende continuar?", "Voltar", MessageBoxButton.YesNo);
            switch (quit)
            {
                case MessageBoxResult.Yes:
                    Perfil p = new Perfil();
                    this.NavigationService.Navigate(p);
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
