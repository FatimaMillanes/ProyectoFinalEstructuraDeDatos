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

namespace ProyectoFinal
{
    /// <summary>
    /// Lógica de interacción para ParametrosNuevos.xaml
    /// </summary>
    public partial class ParametrosNuevos : UserControl
    {
        public ParametrosNuevos()
        {
            InitializeComponent();
        }

        


       private void RadioButton_Checked(object sender, RoutedEventArgs e)
         {
             if (rbPelicula.IsChecked == true) {
                 grdPelis.Children.Add(new ParametrosPeliculas());
                grdSeries.Children.Clear();
               
            }



         }

         private void rbSerie_Checked(object sender, RoutedEventArgs e)
         {
             if (rbSerie.IsChecked == true)
             {
                 grdSeries.Children.Add(new ParametrosSeries());
                grdPelis.Children.Clear();
               
            }
         }

        
    }
}
