using Equipo5.Business;
using Equipo5.Data.Services;
using Equipo5.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Equipo5.Site.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            var bizProducto = new BizProducto();
            var model = bizProducto.TraerTodos().Take(4);

            return View(model);
        }
    }
}