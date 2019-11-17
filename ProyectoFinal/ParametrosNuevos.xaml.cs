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
                txtDirector.Visibility = Visibility.Visible;
                lblDirector.Visibility = Visibility.Visible;
                lblSinopsis.Visibility = Visibility.Visible;

                lblDescripcion.Visibility = Visibility.Hidden;
                lblTemp.Visibility = Visibility.Hidden;
                cbTemp.Visibility = Visibility.Hidden;
                lblProduccion.Visibility = Visibility.Hidden;
                txtProduccion.Visibility = Visibility.Hidden;
            }

         }

         private void rbSerie_Checked(object sender, RoutedEventArgs e)
         {
             if (rbSerie.IsChecked == true)
             {
                txtDirector.Visibility = Visibility.Hidden;
                lblDirector.Visibility = Visibility.Hidden;
                lblSinopsis.Visibility = Visibility.Hidden;

                lblDescripcion.Visibility = Visibility.Visible;
                lblTemp.Visibility = Visibility.Visible;
                cbTemp.Visibility = Visibility.Visible;
                lblProduccion.Visibility = Visibility.Visible;
                txtProduccion.Visibility = Visibility.Visible;
            }
         }

        
    }
}
