using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class Series:Info
    {
     
        public Series(string titulo, int año)
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
