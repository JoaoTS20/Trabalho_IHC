using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    static class Container
    {
        public static List<ANIMAL> animais = new List<ANIMAL>();
        public static List<ANIMAL> favoritos = new List<ANIMAL>();
        public static List<ANIMAL> adocoes = new List<ANIMAL>();
        public static List<ANIMAL> animal_selecionado = new List<ANIMAL>();
        public static List<Produto> produtos = new List<Produto>();
        
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            String s = "Imagens\\"; //Tem de ser assim
            //Façam o mesmo depois para escrever o meses na idade
            Container.animais.Add(new ANIMAL() { Nome = "Cãoasdasd", Idade = "5 meses", Genero = "Masculino", Raca = "Cão", Url_Image = s + "stock_dog1.jpg", User_Name = "Filipa" });
            Container.animais.Add(new ANIMAL() { Nome = "Princesa", Idade = "10 anos", Genero = "Feminino", Raca = "Gato", Url_Image = s + "stock_gato1.jpg", User_Name = "Anthony Pereira" });
            Container.animais.Add(new ANIMAL() { Nome = "Piu", Idade = "5 anos", Genero = "Feminino", Raca = "Cão", Url_Image = s + "stock_dog1.jpg", User_Name = "Anthony Pereira" });
            Container.animais.Add(new ANIMAL() { Nome = "No Name", Idade = "7 anos", Genero = "Feminino", Raca = "Gato", Url_Image = s + "stock_gato1.jpg", User_Name = "Alexandra" });
            Container.animais.Add(new ANIMAL() { Nome = "Stock#1", Idade = "8 meses", Genero = "Masculino", Raca = "Cão", Url_Image = s + "stock_dog1.jpg", User_Name = "João" });
            // separador
            Container.produtos.Add(new Produto() { ID = "1000", TipoServico = "Produto", NomeProduto = "Roupão para cão", Empresa="Empresa A", Preco = "5,95", uImage= s + "escova_cabelo.jpg" });
            Container.produtos.Add(new Produto() { ID = "1001", TipoServico = "Produto", NomeProduto = "Roupão para gato", Empresa = "Empresa B", Preco = "6,95", uImage = s + "escova_cabelo.jpg" });
            Container.produtos.Add(new Produto() { ID = "1002", TipoServico = "Serviço", NomeProduto = "Esterilização para cão", Empresa = "Empresa C", Preco = "15,00", uImage = s + "escova_cabelo.jpg" });
            Container.produtos.Add(new Produto() { ID = "1003", TipoServico = "Serviço", NomeProduto = "Manicure para gato", Empresa = "Empresa D", Preco = "8,99", uImage = s + "escova_cabelo.jpg" });
            Container.produtos.Add(new Produto() { ID = "1003", TipoServico = "Produto", NomeProduto = "Ração tricolor para cão", Empresa = "Empresa E", Preco = "7,99", uImage = s + "escova_cabelo.jpg" });


        }
    }
}
