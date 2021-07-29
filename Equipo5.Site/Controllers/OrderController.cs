using Equipo5.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Equipo5.Site.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            var bizOrder = new BizOrder();
            var model = bizOrder.TraerTodos();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            throw new NotImplementedException();
        }
    }
}