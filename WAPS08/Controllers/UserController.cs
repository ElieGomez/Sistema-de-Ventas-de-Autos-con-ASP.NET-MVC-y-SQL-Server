using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WAPS08.Models;
using WAPS08.Models.ViewModels;

namespace WAPS08.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        // ----------------------------------------------------------------------
        // Consulta Los usuarios que tienen estatus 1
        // ----------------------------------------------------------------------
        public ActionResult Query()
        {
            List<UserTableViewModel> lst = null;   // creo objecto 'lst' tipo lista para ser usado en el select siguiente

            using (DBMVCSCEntities db = new DBMVCSCEntities())  // le indica que esta utilizando el modelo de la bas de datos
            {
                lst = (from d in db.USERS                   // realiza un select a la base de datos
                       where d.idEstatus == 1
                       orderby d.Email

                       select new UserTableViewModel        // haganse de cuenta que esto es un foreach  o  un while
                       {                                    // que va creando una lista
                           _Email = d.Email,
                           _Id = d.ID,
                           _Edad = d.Edad                    // los datos que viene de la base de datos es asignado al modelo 'UserTableViewModel'
                       }).ToList();
            }

            return View(lst);         // el contenedor 'lst' es enviado a la vista 'Index'
        }

        // ----------------------------------------------------------------------
        // Abre la pagina de usuario
        // ----------------------------------------------------------------------
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        // ----------------------------------------------------------------------
        // Agrega un usuario
        // ----------------------------------------------------------------------
        [HttpPost]
        public ActionResult Add(AddUserViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new DBMVCSCEntities())
            {
                USER oUser = new USER();
                oUser.idEstatus = 1;
                oUser.Email = model.Email;
                oUser.Nombre = model.Nombre;
                oUser.Edad = model.Edad;
                oUser.Password = model.Password;

                db.USERS.Add(oUser);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/query"));
        }

        // ----------------------------------------------------------------------
        // Edita un usuario
        // ----------------------------------------------------------------------
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            EditUserViewModels model = new EditUserViewModels();
            using (var db = new DBMVCSCEntities())
            {
                var oUser = db.USERS.Find(Id);  // SELECT * FROM USER WHERE ID = 7
                model.Email = oUser.Email;
                model.Edad = oUser.Edad;
                model.Id = oUser.ID;
            }

            return View(model);
        }

        // ----------------------------------------------------------------------
        // Realiza un Update al usuario
        // ----------------------------------------------------------------------
        [HttpPost]
        public ActionResult Edit(EditUserViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new DBMVCSCEntities())
            {
                var oUser = db.USERS.Find(model.Id);
                oUser.Email = model.Email;
                oUser.Edad = model.Edad;

                if(model.Password != null && model.Password.Trim() != "")
                {
                    oUser.Password = model.Password;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/query"));
        }

        // ----------------------------------------------------------------------
        // Borrar o Marcar un usuario
        // ----------------------------------------------------------------------
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new DBMVCSCEntities())
            {
                var oUser = db.USERS.Find(Id);
                oUser.idEstatus = 3;

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Content("1");
            }
        }
    }
}