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
using System.Collections.ObjectModel;

namespace ProyectoFinal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<int> miLista = new ObservableCollection<int>();
        ObservableCollection<Peliculas> peliculas = new ObservableCollection<Peliculas>();
        public MainWindow()
        {
            InitializeComponent();

            peliculas.Add(new Peliculas("titulo1", 1999));
            peliculas.Add(new Peliculas("titulo3", 1998));
            peliculas.Add(new Peliculas("titulo2", 1955));
            peliculas.Add(new Peliculas("titulo8", 1945));
            peliculas.Add(new Peliculas("titulo5", 1985));
            peliculas.Add(new Peliculas("titulo6", 1927));
            peliculas.Add(new Peliculas("titulo7", 1959));
            peliculas.Add(new Peliculas("titulo4", 1939));
            peliculas.Add(new Peliculas("titulo9", 1949));
            peliculas.Add(new Peliculas("titulo10", 1899));
            lstPelis.ItemsSource = peliculas;
        }

        //Botones para orgnizar
        private void btnOrdenar1_Click(object sender, RoutedEventArgs e)
        {




        }

        private void btnOrdenar2_Click(object sender, RoutedEventArgs e)
        {

           


        }

        private void btnAño_Click(object sender, RoutedEventArgs e)
        {
            bool intercambio = false;
            do
            {
                intercambio = false;
                for (int i = 0; i < peliculas.Count - 1; i++)
                {
                    if (peliculas[i].Año > peliculas[i + 1].Año)
                    {
                        var temp = peliculas[i];
                        peliculas[i] = peliculas[i + 1];
                        peliculas[i + 1] = temp;
                        intercambio = true;
                    }
                }
            } while (intercambio);
        }

        private void btnAño2_Click(object sender, RoutedEventArgs e)
        {
            bool intercambio = false;
            do
            {
                intercambio = false;
                for (int i = 0; i < peliculas.Count - 1; i++)
                {
                    if (peliculas[i].Año > peliculas[i + 1].Año)
                    {
                        var temp = peliculas[i];
                        peliculas[i] = peliculas[i + 1];
                        peliculas[i + 1] = temp;
                        intercambio = true;
                    }
                }
            } while (intercambio);

        }


        //Otros botones
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            btnNuevo.Visibility = Visibility.Hidden;
            btnOrdenar1.Visibility = Visibility.Hidden;
            btnOrdenar2.Visibility = Visibility.Hidden;
            btnAño.Visibility = Visibility.Hidden;
            btnAño2.Visibility = Visibility.Hidden;
            grdNuevo.Children.Add(new ParametrosNuevos());
            btnGuardar.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Visible;
        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            grdNuevo.Children.Clear();
            btnGuardar.Visibility = Visibility.Hidden;
            btnCancelar.Visibility = Visibility.Hidden;
            btnNuevo.Visibility = Visibility.Visible;
            btnOrdenar1.Visibility = Visibility.Visible;
            btnOrdenar2.Visibility = Visibility.Visible;
            btnAño.Visibility = Visibility.Visible;
            btnAño2.Visibility = Visibility.Visible;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
           
            grdNuevo.Children.Clear();
            btnGuardar.Visibility = Visibility.Hidden;
            btnCancelar.Visibility = Visibility.Hidden;
            btnNuevo.Visibility = Visibility.Visible;
            btnOrdenar1.Visibility = Visibility.Visible;
            btnOrdenar2.Visibility = Visibility.Visible;
            btnAño.Visibility = Visibility.Visible;
            btnAño2.Visibility = Visibility.Visible;
        }
        
        //Visualizar elemento
        private void lstPelis_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (lstPelis.SelectedIndex != -1)
            {
                grdNuevo.Children.Clear();
                grdEditar.Children.Add(new VisualizarElemento());
                btnEliminarElemento.Visibility = Visibility.Visible;
                btnCancelar2.Visibility = Visibility.Visible;
                btnEditar.Visibility = Visibility.Visible;
                btnNuevo.Visibility = Visibility.Hidden;
                btnOrdenar1.Visibility = Visibility.Hidden;
                btnOrdenar2.Visibility = Visibility.Hidden;
                btnAño.Visibility = Visibility.Hidden;
                btnAño2.Visibility = Visibility.Hidden;
                btnGuardar.Visibility = Visibility.Hidden;
                btnCancelar.Visibility = Visibility.Hidden;

            }
        }

        //Botones de Visualizar
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            grdEditar.Children.Clear();
            grdEditar.Children.Add(new EditarElemento());
            grdNuevo.Children.Clear();

        }

        private void btnEliminarElemento_Click(object sender, RoutedEventArgs e)
        {
            grdEditar.Children.Clear();
            btnEliminarElemento.Visibility = Visibility.Hidden;
            btnCancelar2.Visibility = Visibility.Hidden;
            btnEditar.Visibility = Visibility.Hidden;
            btnNuevo.Visibility = Visibility.Visible;
            btnOrdenar1.Visibility = Visibility.Visible;
            btnOrdenar2.Visibility = Visibility.Visible;
            btnAño.Visibility = Visibility.Visible;
            btnAño2.Visibility = Visibility.Visible;
        }

        private void btnCancelar2_Click(object sender, RoutedEventArgs e)
        {
            grdEditar.Children.Clear();
            grdNuevo.Children.Clear();
            btnEliminarElemento.Visibility = Visibility.Hidden;
            btnCancelar2.Visibility = Visibility.Hidden;
            btnEditar.Visibility = Visibility.Hidden;
            btnNuevo.Visibility = Visibility.Visible;
            btnOrdenar1.Visibility = Visibility.Visible;
            btnOrdenar2.Visibility = Visibility.Visible;
            btnAño.Visibility = Visibility.Visible;
            btnAño2.Visibility = Visibility.Visible;
        }
    }

    
}
/*int gap, i;
            gap = miLista.Count / 2;
            while (gap > 0)
            {
                for (i = 0; i < peliculas.Count; i++)
                {
                    if (gap + i < peliculas.Count && peliculas[i].Año > peliculas[gap + i].Año)
                    {
                        var temp = peliculas[i];
                        peliculas[i] = peliculas[gap + i];
                        peliculas[gap + i] = temp;
                    }
                }
                gap--;
            }*/
