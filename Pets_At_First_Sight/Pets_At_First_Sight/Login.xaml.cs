using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pets_At_First_Sight
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        bool goodEmail = false;
        bool goodPass = false;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Validação do email
            if (IsValidMailAddress(Email.Text.ToString()) == true)
            {
                // verificar se o user existe
                foreach (Conta c in Container.contas)
                {
                    if (Email.Text.ToString() == c.Email.ToString())
                    {
                        goodEmail = true;
                        break;
                    }
                }
                if (goodEmail == false)
                {
                    MessageBox.Show("Não existe nenhuma conta registada com esse email.");
                    Email.Text = "";
                }
            } else
            {
                MessageBox.Show("Email inválido!");
                Email.Text = "";
            }

            // Validação da password
            if (IsValidPass(PasswordBox.Password.ToString()) == true){
                foreach (Conta c in Container.contas)
                {
                    if (PasswordBox.Password.ToString() == c.Pass.ToString())
                    {
                        goodPass = true;
                        break;
                    } 
                }
                if (goodPass == false)
                {
                    MessageBox.Show("Não existe nenhuma conta registada com essa password");
                    PasswordBox.Password = "";
                }
            } else
            {
                MessageBox.Show("Password inválida! Tem de conter pelo menos 8 caracteres, 1 número e 1 sinal de pontuação!");
                PasswordBox.Password = "";
            }

            if (goodEmail == true && goodPass == true)
            {
                MessageBox.Show("Login efetuado com sucesso!");
                Windows App = new Windows();
                this.NavigationService.Navigate(App);
            }
            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ainda não é possível recuperar a sua password. \n Pedimos desculpa.", "Oops!", MessageBoxButton.OK);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CriarConta cc = new CriarConta();
            this.NavigationService.Navigate(cc);
        }

        private bool IsValidMailAddress(string mailAddress)
        {
            return Regex.IsMatch(mailAddress, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        private bool IsValidPass(string pass) // para validar a password de input do login; no caso da criação de conta, terá de confirmar
            // a utilização e pelo menos um caracter numérico e ainda um sinal de pontuação
        {
            int length = pass.Length;
            bool containsInt = pass.Any(char.IsDigit);
            bool containsPonct = pass.IndexOfAny(".,;:^~='?!-_>&$%#<>".ToCharArray()) != -1;
            if (length >= 8 && containsInt == true && containsPonct == true)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
