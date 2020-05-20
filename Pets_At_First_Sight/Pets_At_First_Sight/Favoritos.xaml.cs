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
    /// Interaction logic for Favoritos.xaml
    /// </summary>
    public partial class Favoritos : Page
    {
        public Favoritos()
        {
            InitializeComponent();

            My_Favoritos.ItemsSource = Container.favoritos;
            CollectionViewSource.GetDefaultView(Container.favoritos).Refresh(); //faltava esta linha
        }



    }
}
