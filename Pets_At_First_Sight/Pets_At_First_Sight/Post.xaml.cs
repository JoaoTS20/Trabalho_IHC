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
    public partial class Page1 : Page
    {
        public Page1()
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
            String Especie = EspecieAnimal.SelectedItem.ToString();
            String Nome = NomeAnimal.Text.ToString();
            String Idade = IdadeAnimal.SelectedItem.ToString();
            String Genero = GeneroAnimal.SelectedItem.ToString();
            String _TipoDoador = TipoDoador.SelectedItem.ToString();
            String _NomeDoador = NomeDoador.Text.ToString();
            String _Vacinas = Vacinas.SelectedItem.ToString();
            String _Chip = Chip.SelectedItem.ToString();
            String Testo = PostTexto.Text.ToString();
            String s = "Imagens\\";
            ANIMAL N1 = new ANIMAL()
            {
                Nome = Nome,
                Idade = Idade,
                Genero = Genero,
                Raca = Especie,
                Url_Image = s + "stock_dog1.jpg",
                User_Name = _NomeDoador
            };
            Container.animais.Add(N1);
            Perfil cursosPage = new Perfil();
            this.NavigationService.Navigate(cursosPage);
                    }
    }
}
