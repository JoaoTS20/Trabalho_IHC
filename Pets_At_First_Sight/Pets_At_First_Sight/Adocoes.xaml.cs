﻿using System;
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
    /// Interaction logic for Adocoes.xaml
    /// </summary>
    public partial class Adocoes : Page
    {
        public Adocoes()
        {
            InitializeComponent();
            My_Adocoes.ItemsSource = Container.adocoes;
            CollectionViewSource.GetDefaultView(Container.adocoes).Refresh(); //faltava esta linha
        }

        

        private void abandonar(object sender, RoutedEventArgs e)
        {
            Button i = (Button)sender;
            Image b = (Image)i.Content;
            StackPanel s = (StackPanel)i.Parent;
            Grid gr = (Grid)s.Parent;
            //Image u = (Image)gr.Children[1];
            //String x = u.Source.ToString(); //Não dá o texto de forma correta
            Label r = (Label)gr.Children[1];
            Label n = (Label)gr.Children[2];
            Label y = (Label)gr.Children[3];
            Label g = (Label)gr.Children[4];

            String Nome_Bicho = n.Content.ToString();
            String Idades = y.Content.ToString();
            String Raca = r.Content.ToString();
            String genero = g.Content.ToString();
            if (true)
            {
                foreach (ANIMAL zzs in Container.animais)
                {
                    if (zzs.Nome == Nome_Bicho && zzs.Idade == Idades)
                    {
                        Container.adocoes.Remove(zzs);
                        new Adocoes();
                        break;

                    }

                }
            }


        }
    }
}
