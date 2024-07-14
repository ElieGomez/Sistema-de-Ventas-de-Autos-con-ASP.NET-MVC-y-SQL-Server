using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WAPS08.Models.ViewModels
{
    public class AutoTableViewModel
    {
        public int _Idauto { get; set; }
        public string _Marca { get; set; }    
        public string _Modelo { get; set; }
        public string _Anio { get; set; }
        public string _Color { get; set; }
        public string _Imagen { get; set; }
        public double _Precio { get; set; }
        public string _TipoVehiculo { get; set; }
        public string _Direccion { get; set; }
    }

    public class AddAutoViewModels
    {
        [Required]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Required]
        [Display(Name = "Modelo Del Vehiculo")]
        public string Modelo { get; set; }

        [Required]
        [Display(Name = "Año Del Vehiculo")]
        public string Anio { get; set; }

        [Required]
        [Display(Name = "Ruta de la Imagen")]
        public string Imagen { get; set; }
        [Required]
        [Display(Name = "Color del Vehiculo")]
        public string Color { get; set; }
        [Required]
        [Display(Name = "Precio del Vehiculo")]
        public double Precio { get; set; }
        [Required]
        [Display(Name = "Tipo del Vehiculo")]
        public string TipoVehiculo { get; set; }
        [Required]
        [Display(Name = "Direccion del Vehiculo")]
        public string Direccion { get; set; }
    }

    public class EditAutoViewModels
    {
        public int IdAuto { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Required]
        [Display(Name = "Modelo Del Vehiculo")]
        public string Modelo { get; set; }

        [Required]
        [Display(Name = "Ano Del Vehiculo")]
        public string Anio { get; set; }



        [Display(Name = "Ruta de la Imagen")]
        public string Imagen { get; set; }


        [Required]
        [Display(Name = "Color del Vehiculo")]
        public string Color { get; set; }


        [Required]
        [Display(Name = "Precio del Vehiculo")]
        public double Precio { get; set; }


        [Required]
        [Display(Name = "Tipo del Vehiculo")]
        public string TipoVehiculo { get; set; }


        [Required]
        [Display(Name = "Direccion del Vehiculo")]
        public string Direccion { get; set; }
    }
}