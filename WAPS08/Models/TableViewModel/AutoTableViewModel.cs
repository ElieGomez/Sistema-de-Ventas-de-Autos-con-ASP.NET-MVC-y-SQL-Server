using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAPS08.Models.TableViewModel
{
    public class AutoTableViewModel
    {
        public int _Idauto { get; set; }
        public string _Marca { get; set; }    // declara la variable a usar en la vista 'Index'
        public string _Modelo { get; set; }
        public string _Anio { get; set; }
        public string _Imagen { get; set; }
    }
}