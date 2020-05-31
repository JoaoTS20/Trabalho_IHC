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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pets_At_First_Sight
{
    /// <summary>
    /// Interaction logic for CriarConta.xaml
    /// </summary>
    public partial class CriarConta : Page
    {
        public CriarConta()
        {
            InitializeComponent();
        }
   
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (criar_localidade.Text == "" || criar_nome.Text == "" || criar_username.Text == "")
            {
                MessageBox.Show("Existem 1 ou mais campos em branco!");
            }

            if (CheckUsername(criar_username.Text.ToString()) == false)
            {
                MessageBox.Show("Já existe uma conta associada a esse username.");
                criar_username.Text = "";
            }

            if (IsValidMailAddress(criar_email.Text.ToString()) == false)
            {
                MessageBox.Show("Email inválido!");
                criar_email.Text = "";
            } else if (IsValidMailAddress(criar_email.Text.ToString()) == true)
            {
                if (CheckEmail(criar_email.Text.ToString()) == false)
                {
                    MessageBox.Show("Já existe uma conta associada a esse email.");
                    criar_email.Text = "";
                }
            }

            if (IsValidPass(criar_pass.Password.ToString()) == false)
            {
                MessageBox.Show("Password inválida! Tem de conter pelo menos 8 caracteres, 1 número e 1 sinal de pontuação!");
                criar_pass.Password = "";
            }

            if (CheckEmail(criar_email.Text.ToString()) == true && CheckUsername(criar_username.Text.ToString()) == true)
            {
                if (IsValidMailAddress(criar_email.Text.ToString()) == true && IsValidPass(criar_pass.Password.ToString()) == true)
                {
                    MessageBox.Show("Conta criada com sucesso!");
                    Container.contas.Add(new Conta() { Email = criar_email.Text.ToString(), Pass = criar_pass.Password.ToString(), NomePessoa = criar_nome.Text.ToString(), Username = criar_username.Text.ToString(), TipoConta = "Particular", Localidade = criar_localidade.Text.ToString() });
                    Login login = new Login();
                    this.NavigationService.Navigate(login);
                }
            }

        }

        public bool CheckEmail(string email)
        {
            int exist = 0;
            foreach (Conta c in Container.contas)
            {
                if (email == c.Email.ToString())
                {
                    exist = exist + 1;
                }
            }
            if (exist == 0)
            {
                return true;
            } else if (exist > 0) // nomeadamente se for 1, é porque já existe alguém com esse email
            {
                return false;
            } else
            {
                return false;
            }
        }

        public bool CheckUsername(string username)
        {
            int exist = 0;
            foreach (Conta c in Container.contas)
            {
                if (username == c.Username.ToString())
                {
                    exist = exist + 1;
                }
            }
            if (exist == 0)
            {
                //MessageBox.Show("yay sou o primeiro");
                return true;
            }
            else if (exist > 0) // nomeadamente se for 1, é porque já existe alguém com esse username
            {
                return false;
            }
            else
            {
                return false;
            }
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
            }
            else
            {
                return false;
            }
        }
    }
}
