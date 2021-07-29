using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Equipo5.Business;

namespace Equipo5.Site.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var bizProducto = new BizProducto();
            ViewBag.CantProductos = bizProducto.TraerTodos().Count;

            var bizUsuario = new BizUsuario();
            ViewBag.CantUsuarios = bizUsuario.TraerTodos().Count;

            var bizCategory = new BizCategory();
            ViewBag.CantCategoriasProducto = bizCategory.TraerTodos().Count;

            var bizOrders = new BizOrder();
            ViewBag.CantOrders = bizOrders.TraerTodos().Count;

            var bizCarritos = new BizCarrito();
            ViewBag.CantCarritos = bizCarritos.TraerTodos().Count;

            return View();
        }
    }
}