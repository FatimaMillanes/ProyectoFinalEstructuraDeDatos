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

            Peliculas peliculas1 = new Peliculas("Pelicula","Suicide Squad", 2016, "Accion", "Fatima Millanes","Sinopsis",5);
            Peliculas peliculas2 = (new Peliculas("Pelicula", "Wonder Woman", 2017, "Accion", "Director", "Sinopsis", 5));
            Peliculas peliculas3 = (new Peliculas("Pelicula", "Batman vs Superman", 2016, "Accion", "Director", "Sinopsis", 5));
            Peliculas peliculas4 = (new Peliculas("Pelicula", "The Dark Knight", 2008, "Accion", "Director", "Sinopsis", 5));
            Peliculas peliculas5 = (new Peliculas("Pelicula", "Man of Steel", 2013, "Accion", "Director", "Sinopsis", 5));
            Series series1 = (new Series("Serie", "Supergirl", 2015, "Accion", "Director", "Sinopsis", 5));
            Series series2 = (new Series("Serie", "Flash", 2014, "Accion", "Director", "Sinopsis", 5));
            Series series3 = (new Series("Serie", "Arrow", 2012, "Accion", "Director", "Sinopsis", 5));
            Series series4 = (new Series("Serie", "Titans", 2018, "Accion", "Director", "Sinopsis", 5));
            Series series5 = (new Series("Serie", "Legends of Tomorrow", 2016, "Accion", "Director", "Sinopsis", 5));


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

            
            txtTitulo.Visibility = Visibility.Visible;
            txtAño.Visibility = Visibility.Visible;
            lblTitulo.Visibility = Visibility.Visible;
            lblAño.Visibility = Visibility.Visible;





        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            
            btnGuardar.Visibility = Visibility.Hidden;
            btnCancelar.Visibility = Visibility.Hidden;
            btnNuevo.Visibility = Visibility.Visible;
            btnOrdenar1.Visibility = Visibility.Visible;
            btnOrdenar2.Visibility = Visibility.Visible;
            btnAño.Visibility = Visibility.Visible;
            btnAño2.Visibility = Visibility.Visible;

            if (((ParametrosNuevos)(grdEditar.Children[0])).rbPelicula.IsChecked == true && 
                ((ParametrosNuevos)(grdEditar.Children[0])).rbSerie.IsChecked == false)
            {
                Informacion.Add(new Peliculas("Pelicula", txtTitulo.Text, Int32.Parse(txtAño.Text), "", "", "",0)) ;
                txtTitulo.Text = "";
                txtAño.Text = "";
               
            }

            if (((ParametrosNuevos)(grdEditar.Children[0])).rbPelicula.IsChecked == false &&
                ((ParametrosNuevos)(grdEditar.Children[0])).rbSerie.IsChecked == true)
            {
                Informacion.Add(new Series("Serie", txtTitulo.Text, Int32.Parse(txtAño.Text), "", "", "", 0));
                txtTitulo.Text = "";
                txtAño.Text = "";
            }
            grdEditar.Children.Clear();
            txtTitulo.Visibility = Visibility.Hidden;
            txtAño.Visibility = Visibility.Hidden;
            lblTitulo.Visibility = Visibility.Hidden;
            lblAño.Visibility = Visibility.Hidden;


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

            txtTitulo.Visibility = Visibility.Hidden;
            txtAño.Visibility = Visibility.Hidden;
            lblTitulo.Visibility = Visibility.Hidden;
            lblAño.Visibility = Visibility.Hidden;
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

                txtTitulo.Visibility = Visibility.Hidden;
                txtAño.Visibility = Visibility.Hidden;
                lblTitulo.Visibility = Visibility.Hidden;
                lblAño.Visibility = Visibility.Hidden;


                ((VisualizarElemento)(grdEditar.Children[0])).txtTipo.Text = Informacion[lstPelis.SelectedIndex].Tipo;
                ((VisualizarElemento)(grdEditar.Children[0])).txtTitulo.Text = Informacion[lstPelis.SelectedIndex].Titulo;
                ((VisualizarElemento)(grdEditar.Children[0])).txtAño.Text = Informacion[lstPelis.SelectedIndex].Año.ToString();
                ((VisualizarElemento)(grdEditar.Children[0])).txtGenero.Text = Informacion[lstPelis.SelectedIndex].Genero;
                ((VisualizarElemento)(grdEditar.Children[0])).txtDirector.Text = Informacion[lstPelis.SelectedIndex].Director;
                ((VisualizarElemento)(grdEditar.Children[0])).txtSinopsis.Text = Informacion[lstPelis.SelectedIndex].Sinopsis;
                

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

            if (lstPelis.SelectedIndex != -1)
            {
                Informacion.RemoveAt(lstPelis.SelectedIndex);
            }
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
