using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class Info
    {
        ObservableCollection<Info> Informacion = new ObservableCollection<Info>();
        public string Titulo { get; set; }
        public int Año { get; set; }

        
    }
}
