using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class Series
    {
        public string Titulo { get; set; }
        public float Año { get; set; }

        public Series(string titulo, float año)
        {
            this.Titulo = titulo;
            this.Año = año;
        }
        public override string ToString()
        {
            return this.Titulo + "" + "(" + this.Año.ToString() + ")";
        }
    }
}
