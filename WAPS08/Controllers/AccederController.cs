using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAPS08.Models;

namespace WAPS08.Controllers
{
    public class AccederController : Controller
    {
        // GET: Acceder
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Enter(string usuario, string password)
        {
            try
            {
                using (DBMVCSCEntities db = new DBMVCSCEntities())
                {
                    var read = from d in db.USERS
                              where d.Email == usuario 
                                 && d.Password == password 
                                 && d.idEstatus == 1
                              select d;
                    if (read.Count() > 0)
                    {
                        Session["Usuario"] = read.First();
                        return Content("1");
                    }
                    else
                    {
                        return Content("Revisa usuario y password...");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :(" + ex.Message);
            }
        }
    }
}