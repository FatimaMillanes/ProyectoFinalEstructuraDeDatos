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
        private object txtAño;

        public MainWindow()
        {
            InitializeComponent();

            Peliculas peliculas1 = new Peliculas("Pelicula","Suicide Squad", 2016, "Accion", "David Ayer", "Los peores villanos de las cárceles y hospitales psiquiátricos, todos poseedores de cualidades especiales, son liberados por el gobierno para conformar un equipo de luchadores de élite y detener a una misteriosa y poderosa entidad.", 2);
            Peliculas peliculas2 = (new Peliculas("Pelicula", "Wonder Woman", 2017, "Accion", "Patty Jenkins", "Cuando un piloto se estrella y habla de un conflicto en el mundo exterior, Diana, una guerrera amazónica en entrenamiento, abandona su hogar para luchar en una guerra, descubriendo sus plenos poderes y su verdadero destino.", 4));
            Peliculas peliculas3 = (new Peliculas("Pelicula", "Batman vs Superman", 2016, "Accion", "Zack Snyder", "Temiendo que las acciones de Superman no se controlen, Batman se enfrenta al Hombre de Acero, mientras el mundo lucha con el tipo de héroe que realmente necesita.", 3));
            Peliculas peliculas4 = (new Peliculas("Pelicula", "The Dark Knight", 2008, "Accion", "Christopher Nolan", "Cuando la amenaza conocida como el Joker causa estragos y caos en la gente de Gotham, Batman debe aceptar una de las mayores pruebas psicológicas y físicas de su capacidad para luchar contra la injusticia.", 5));
            Peliculas peliculas5 = (new Peliculas("Pelicula", "Man of Steel", 2013, "Accion", "Zack Snyder", "Clark Kent es un extraterrestre que de niño fue evacuado de su mundo moribundo y vino a la Tierra, viviendo como un humano normal. Pero cuando los sobrevivientes de su hogar alienígena invaden la Tierra, debe revelarse al mundo.", 3));
            Series series1 = (new Series("Serie", "Supergirl", 2015, "Accion", "Ali Adler", "Las aventuras de la prima de Superman en su propia carrera de superhéroes.", 2));
            Series series2 = (new Series("Serie", "The Flash", 2014, "Accion", "Greg Berlanti", "Después de ser alcanzado por un rayo, Barry Allen se despierta de su coma y descubre que se le ha dado el poder de la súper velocidad, convirtiéndose en Flash, luchando contra el crimen en Central City.", 3));
            Series series3 = (new Series("Serie", "Arrow", 2012, "Accion", "Greg Berlanti", "El playboy multimillonario Oliver Queen está desaparecido y se presume muerto cuando su yate se pierde en el mar. Regresa cinco años más tarde, un hombre cambiado, decidido a limpiar la ciudad como un vigilante encapuchado armado con un arco.", 4));
            Series series4 = (new Series("Serie", "Titans", 2018, "Accion", "Greg Berlanti", "Un equipo de jóvenes superhéroes combate el mal y otros peligros.", 4));
            Series series5 = (new Series("Serie", "Legends of Tomorrow", 2016, "Accion", "Greg Berlanti", "Rip Hunter, un viajero en el tiempo, tiene que reclutar un equipo de héroes y villanos para ayudar a prevenir un apocalipsis que podría afectar no solo a la Tierra, sino a todo el tiempo.", 3));


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
            

            /* txtTitulo.Visibility = Visibility.Visible;
             txtAño.Visibility = Visibility.Visible;
             lblTitulo.Visibility = Visibility.Visible;
             lblAño.Visibility = Visibility.Visible;


             */


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
                Informacion.Add(new Peliculas("Pelicula", ((ParametrosNuevos)(grdEditar.Children[0])).txtTitulo.Text,
                    Int32.Parse(((ParametrosNuevos)(grdEditar.Children[0])).txtAño.Text), 
                    ((ParametrosNuevos)(grdEditar.Children[0])).txtGenero.Text, 
                    ((ParametrosNuevos)(grdEditar.Children[0])).txtDirector.Text,
                    ((ParametrosNuevos)(grdEditar.Children[0])).txtDescripcion.Text,
                    ((ParametrosNuevos)(grdEditar.Children[0])).cbRat.SelectedIndex
                    ));
                
                (((ParametrosNuevos)(grdEditar.Children[0])).txtTitulo.Text) = "";
                ((ParametrosNuevos)(grdEditar.Children[0])).txtAño.Text = "";
                (((ParametrosNuevos)(grdEditar.Children[0])).txtGenero.Text) = "";
                (((ParametrosNuevos)(grdEditar.Children[0])).txtDirector.Text) = "";
                (((ParametrosNuevos)(grdEditar.Children[0])).txtDescripcion.Text) = "";
                ((ParametrosNuevos)(grdEditar.Children[0])).cbRat.SelectedIndex = 0;

            }

            if (((ParametrosNuevos)(grdEditar.Children[0])).rbPelicula.IsChecked == false &&
                ((ParametrosNuevos)(grdEditar.Children[0])).rbSerie.IsChecked == true)
            {
               Informacion.Add(new Series("Serie", ((ParametrosNuevos)(grdEditar.Children[0])).txtTitulo.Text,
                    Int32.Parse(((ParametrosNuevos)(grdEditar.Children[0])).txtAño.Text),
                    ((ParametrosNuevos)(grdEditar.Children[0])).txtGenero.Text,
                    ((ParametrosNuevos)(grdEditar.Children[0])).txtProduccion.Text,
                    ((ParametrosNuevos)(grdEditar.Children[0])).txtDescripcion.Text,
                    ((ParametrosNuevos)(grdEditar.Children[0])).cbRat.SelectedIndex
                    ));

                (((ParametrosNuevos)(grdEditar.Children[0])).txtTitulo.Text) = "";
                ((ParametrosNuevos)(grdEditar.Children[0])).txtAño.Text = "";
                (((ParametrosNuevos)(grdEditar.Children[0])).txtGenero.Text) = "";
                (((ParametrosNuevos)(grdEditar.Children[0])).txtDirector.Text) = "";
                (((ParametrosNuevos)(grdEditar.Children[0])).txtDescripcion.Text) = "";
                ((ParametrosNuevos)(grdEditar.Children[0])).cbRat.SelectedIndex = 0;
            }
            grdEditar.Children.Clear();



           /* txtTitulo.Visibility = Visibility.Hidden;
            txtAño.Visibility = Visibility.Hidden;
            lblTitulo.Visibility = Visibility.Hidden;
            lblAño.Visibility = Visibility.Hidden;
            */

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
        

            /*  txtTitulo.Visibility = Visibility.Hidden;
              txtAño.Visibility = Visibility.Hidden;
              lblTitulo.Visibility = Visibility.Hidden;
              lblAño.Visibility = Visibility.Hidden;*/
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

               /* txtTitulo.Visibility = Visibility.Hidden;
                txtAño.Visibility = Visibility.Hidden;
                lblTitulo.Visibility = Visibility.Hidden;
                lblAño.Visibility = Visibility.Hidden;
                */

                ((VisualizarElemento)(grdEditar.Children[0])).txtTipo.Text = Informacion[lstPelis.SelectedIndex].Tipo;
                ((VisualizarElemento)(grdEditar.Children[0])).txtTitulo.Text = Informacion[lstPelis.SelectedIndex].Titulo;
                ((VisualizarElemento)(grdEditar.Children[0])).txtAño.Text = Informacion[lstPelis.SelectedIndex].Año.ToString();
                ((VisualizarElemento)(grdEditar.Children[0])).txtGenero.Text = Informacion[lstPelis.SelectedIndex].Genero;
                ((VisualizarElemento)(grdEditar.Children[0])).txtDirector.Text = Informacion[lstPelis.SelectedIndex].Director;
                ((VisualizarElemento)(grdEditar.Children[0])).txtSinopsis.Text = Informacion[lstPelis.SelectedIndex].Sinopsis;
                ((VisualizarElemento)(grdEditar.Children[0])).txtRating.Text = Informacion[lstPelis.SelectedIndex].Rating.ToString();

                if (((VisualizarElemento)(grdEditar.Children[0])).txtRating.Text=="0")
                {
                    spStars.Visibility = Visibility.Hidden;
                    star1.Visibility = Visibility.Hidden;
                    star2.Visibility = Visibility.Hidden;
                    star3.Visibility = Visibility.Hidden;
                    star4.Visibility = Visibility.Hidden;
                    star5.Visibility = Visibility.Hidden;
                }
                if (((VisualizarElemento)(grdEditar.Children[0])).txtRating.Text == "1")
                {
                    spStars.Visibility = Visibility.Visible;

                    star1.Visibility = Visibility.Visible;
                    star2.Visibility = Visibility.Hidden;
                    star3.Visibility = Visibility.Hidden;
                    star4.Visibility = Visibility.Hidden;
                    star5.Visibility = Visibility.Hidden;

                }
                if (((VisualizarElemento)(grdEditar.Children[0])).txtRating.Text == "2")
                {

                    spStars.Visibility = Visibility.Visible;
                    star1.Visibility = Visibility.Visible;
                    star2.Visibility = Visibility.Visible;
                    star3.Visibility = Visibility.Hidden;
                    star4.Visibility = Visibility.Hidden;
                    star5.Visibility = Visibility.Hidden;
                }
                if (((VisualizarElemento)(grdEditar.Children[0])).txtRating.Text == "3")
                {
                    spStars.Visibility = Visibility.Visible;
                    star1.Visibility = Visibility.Visible;
                    star2.Visibility = Visibility.Visible;
                    star3.Visibility = Visibility.Visible;
                    star4.Visibility = Visibility.Hidden;
                    star5.Visibility = Visibility.Hidden;
                }
                if (((VisualizarElemento)(grdEditar.Children[0])).txtRating.Text == "4")
                {
                    spStars.Visibility = Visibility.Visible;
                    star1.Visibility = Visibility.Visible;
                    star2.Visibility = Visibility.Visible;
                    star3.Visibility = Visibility.Visible;
                    star4.Visibility = Visibility.Visible;
                    star5.Visibility = Visibility.Hidden;
                }
                if (((VisualizarElemento)(grdEditar.Children[0])).txtRating.Text == "5")
                {
                    spStars.Visibility = Visibility.Visible;
                    star1.Visibility = Visibility.Visible;
                    star2.Visibility = Visibility.Visible;
                    star3.Visibility = Visibility.Visible;
                    star4.Visibility = Visibility.Visible;
                    star5.Visibility = Visibility.Visible;
                }


            }
        }

        //Botones de Visualizar
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            grdEditar.Children.Clear();
            grdEditar.Children.Add(new EditarElemento());
            spStars.Visibility = Visibility.Hidden;

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
            spStars.Visibility = Visibility.Hidden;

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
            spStars.Visibility = Visibility.Hidden;
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
