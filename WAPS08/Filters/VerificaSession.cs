using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAPS08.Models;
using WAPS08.Controllers;

namespace WAPS08.Filters
{
    public class VerificaSession : ActionFilterAttribute 
    {
        // para que esto funcione debemos declarar que tendremos este filtro en app_start
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var elUsuario = (USER)HttpContext.Current.Session["Usuario"];

            if (elUsuario == null)
            {
                if (filterContext.Controller is AccederController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Acceder/Login");
                }
            }
            else
            {
                if (filterContext.Controller is AccederController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}