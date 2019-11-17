using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class Peliculas:Info
    {
        
       
        public Peliculas(string tipo, string titulo, int año, string genero, string director, string sinopsis, int rating)
        {
            this.Tipo = tipo;
            this.Titulo = titulo;
            this.Año = año;
            this.Genero = genero;
            this.Director = director;
            this.Sinopsis = sinopsis;
            this.Rating = rating;
        }
        public override string ToString()
        {
            return this.Titulo + "" + "(" + this.Año.ToString() + ")";
        }

    }
}
