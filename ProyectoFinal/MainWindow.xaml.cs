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
using System.ComponentModel;

namespace ProyectoFinal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ObservableCollection<int> miLista = new ObservableCollection<int>();
        ObservableCollection<Info> Informacion = new ObservableCollection<Info>();
        ObservableCollection<Peliculas> peliculas = new ObservableCollection<Peliculas>();
        ObservableCollection<Series> series = new ObservableCollection<Series>();
        public MainWindow()
        {
            InitializeComponent();

            Peliculas peliculas1 = new Peliculas("Aquaman", 2018);
            Peliculas peliculas2 = (new Peliculas("Wonder Woman", 2017));
            Peliculas peliculas3 = (new Peliculas("Batman vs Superman", 2016));
            Peliculas peliculas4 = (new Peliculas("The Dark Knight", 2008));
            Peliculas peliculas5 = (new Peliculas("Man of Steel", 2013));
            Series series1 = (new Series("Supergirl", 2015));
            Series series2 = (new Series("Flash", 2014));
            Series series3 = (new Series("Arrow", 2012));
            Series series4 = (new Series("Gotham", 2014));
            Series series5 = (new Series("Legends of Tomorrow", 2016));


            Informacion.Add(peliculas1);
            Informacion.Add(peliculas2);
            Informacion.Add(peliculas3);
            Informacion.Add(peliculas4);
            Informacion.Add(peliculas5);
            Informacion.Add(series1);
            Informacion.Add(series2);
            Informacion.Add(series3);
            Informacion.Add(series4);
            Informacion.Add(series5);


            lstPelis.ItemsSource = Informacion;
            


        }

        //Botones para orgnizar
        private void btnOrdenar1_Click(object sender, RoutedEventArgs e) //Alfabeticamente Ascendente
        {
            lstPelis.Items.SortDescriptions.Clear();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstPelis.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Titulo", ListSortDirection.Ascending));

        }

        private void btnOrdenar2_Click(object sender, RoutedEventArgs e) //Alfabeficamente Descendente
        {
            lstPelis.Items.SortDescriptions.Clear();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstPelis.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Titulo", ListSortDirection.Descending));

        }

        private void btnAño_Click(object sender, RoutedEventArgs e) //Años Ascendente
        {
            lstPelis.Items.SortDescriptions.Clear();
            bool intercambio = false;
            do
            {
                intercambio = false;
                for (int i = 0; i < Informacion.Count - 1; i++)
                {
                    if (Informacion[i].Año > Informacion[i + 1].Año)
                    {
                        var temp = Informacion[i];
                        Informacion[i] = Informacion[i + 1];
                        Informacion[i + 1] = temp;
                        intercambio = true;
                    }
                }
            } while (intercambio);
        }

        private void btnAño2_Click(object sender, RoutedEventArgs e) //Años Descendente
        {
            lstPelis.Items.SortDescriptions.Clear();
            bool intercambio = false;
            do
            {
                intercambio = false;
                for (int i = 0; i < Informacion.Count - 1; i++)
                {
                    if (Informacion[i].Año < Informacion[i + 1].Año)
                    {
                        var temp = Informacion[i];
                        Informacion[i] = Informacion[i + 1];
                        Informacion[i + 1] = temp;
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
            grdEditar.Children.Add(new ParametrosNuevos());
            btnGuardar.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Visible;
        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            grdEditar.Children.Clear();
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
           
            grdEditar.Children.Clear();
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
                
                grdEditar.Children.Clear();
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
