using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAPS08.Models.TableViewModel
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
}