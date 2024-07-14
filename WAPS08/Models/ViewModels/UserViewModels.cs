using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WAPS08.Models.ViewModels
{
    public class UserTableViewModel
    {
        // ---------------------------------------------------------------------------------------------------------
        // esta variable son las que utilizaremos para representar los campos de entrada de datos en la vista 'Index'
        // y en el controller 'UserController'
        // ---------------------------------------------------------------------------------------------------------
        public int _Id { get; set; }
        public string _Email { get; set; }    // declara la variable a usar en la vista 'Index'
        public int? _Edad { get; set; }
    }

    public class AddUserViewModels
    {
        [Required]
        [Display(Name = "Nombre Corto")]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name ="Correo Electronico")]
        [StringLength(100,ErrorMessage ="El {0} debe tener al menos {1} caracter", MinimumLength =1)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirma Password")]
        [Compare("Password", ErrorMessage ="Las contrasenas no son iguales :(")]
        public string ConfirmaPassword { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int Edad { get; set; }
    }

    public class EditUserViewModels
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electronico")]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirma Password")]
        [Compare("Password", ErrorMessage = "Las contrasenas no son iguales :(")]
        public string ConfirmaPassword { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int Edad { get; set; }
    }
}