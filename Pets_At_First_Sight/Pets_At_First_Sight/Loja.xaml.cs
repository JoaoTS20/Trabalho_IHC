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
    /// Interaction logic for Loja.xaml
    /// </summary>
    public partial class Loja : Page
    {
        public Loja()
        {
            InitializeComponent();
            My_Loja.ItemsSource = Container.produtos;
            CollectionViewSource.GetDefaultView(Container.produtos).Refresh(); //faltava esta linha
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LojaFiltros lojaFiltros = new LojaFiltros();
            NavigationService.Navigate(lojaFiltros);
        }
    }
}
