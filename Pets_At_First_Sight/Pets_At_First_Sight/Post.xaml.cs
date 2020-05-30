using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            String Especie = EspecieAnimal.Text.ToString();
            String Nome = NomeAnimal.Text.ToString();
            String Idade = IdadeAnimal.Text.ToString();
            String Genero = GeneroAnimal.Text.ToString();
            String _TipoDoador = TipoDoador.Text.ToString();
            String _NomeDoador = NomeDoador.Text.ToString();
            String _Vacinas = Vacinas.Text.ToString();
            String _Chip = Chip.Text.ToString();
            String Testo = PostTexto.Text.ToString();
            // String _TipoDoador = TipoDoador.SelectedItem.ToString();
            String s = "Imagens\\";
            ANIMAL N1 = new ANIMAL()
            {
                Nome = Nome,
                Idade = Idade,
                Genero = Genero,
                Raca = Especie,
                Url_Image = InputImage.Source.ToString(),
                User_Name = _NomeDoador,
                Mensagem = Testo

            };
            Container.animais.Add(N1);
            new Inicio(); //MILAGRE
            Perfil cursosPage = new Perfil();
            this.NavigationService.Navigate(cursosPage);
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
