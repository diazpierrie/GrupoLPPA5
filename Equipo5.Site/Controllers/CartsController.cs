using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Caching;
using System.Web;
using System.Web.Mvc;
using Equipo5.Business;
using System.Web.Services.Description;
using Equipo5.Data;
using Equipo5.Entities.Models;

namespace Equipo5.Site.Controllers
{
    public class CartsController : Controller
    {
        private Equipo5DbContext db = new Equipo5DbContext();

        // GET: Carrito
        public ActionResult Index()
        {
            var bizCarrito = new BizCarrito();
            var model = bizCarrito.TraerTodos();
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult MyCart()
        {
            var model = new List<CartItem>();

            if (HttpRuntime.Cache.Get("Carrito") != null)
            {
                var items = GetItemsFromCache();
                var bizProducto = new BizProducto();
                decimal total = 0;

                foreach (var item in items)
                {
                    item.Product = bizProducto.TraerPorId(item.ProductId);
                    total += item.Cantidad * item.Product.Precio;
                }
                ViewBag.PrecioTotal = total;
                model = items;
            }


            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult ItemCart(int idProducto, int cantidad = 1)
        {
            if (HttpRuntime.Cache.Get("Carrito") != null)
            {
                var items = GetItemsFromCache();

                var itemExistente = items.Exists(p => p.ProductId == idProducto);

                if (itemExistente)
                {
                    items.Where(p => p.ProductId == idProducto).ToList().ForEach(p => p.Cantidad = cantidad);
                }
                else
                {
                    var nuevoItem = new CartItem();
                    var bizProducto = new BizProducto();
                    var producto = bizProducto.TraerPorId(idProducto);

                    nuevoItem.Cantidad = cantidad;
                    nuevoItem.Product = producto;
                    nuevoItem.ProductId = producto.Id;
                    items.Add(nuevoItem);
                }
                InsertItemsIntoCache(items);
            }
            else
            {
                var nuevoItem = new CartItem();
                var items = new List<CartItem>();
                var bizProducto = new BizProducto();
                var producto = bizProducto.TraerPorId(idProducto);

                nuevoItem.Cantidad = cantidad;
                nuevoItem.Product = producto;
                nuevoItem.ProductId = producto.Id;
                items.Add(nuevoItem);
                InsertItemsIntoCache(items);
            }
            return RedirectToAction("MyCart");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult DeleteItemCart(int idProducto)
        {
            var items = GetItemsFromCache();
            var itemToRemove = items.Single(i => i.ProductId == idProducto);

            items.Remove(itemToRemove);
            InsertItemsIntoCache(items);

            return RedirectToAction("MyCart");
        }

        [HttpGet]
        public ActionResult CheckOut()
        {
            if (HttpRuntime.Cache.Get("Carrito") != null)
            {
                var bizUsuario = new BizUsuario();
                var bizCarrito = new BizCarrito();
                var carrito = new Cart();

                var items = GetItemsFromCache();
                var usuario = bizUsuario.TraerPorEmail(User.Identity.Name);
                carrito.UsuarioId = usuario.Id;

                var nuevoCarrito = bizCarrito.Agregar(carrito);

                foreach (var item in items)
                {
                    item.CartId = nuevoCarrito.Id;
                    bizCarrito.AgregarCartItem(item);
                }
                HttpRuntime.Cache.Remove("Carrito");
                return RedirectToAction("MisCompras", "Carts");
            }
            else
            {
                return RedirectToAction("MyCart");
            }

        }
        [HttpGet]
        public ActionResult MisCompras()
        {
            var bizUsuario = new BizUsuario();
            var usuario = bizUsuario.TraerPorEmail(User.Identity.Name);
            var compras = usuario.Carrito;

            return View(compras);
}

        private void InsertItemsIntoCache(List<CartItem> items)
        {
            var itemsXml = Data.Services.Serializer.ObjectToXml(items);
            HttpRuntime.Cache.Insert("Carrito", itemsXml, null, DateTime.Now.AddHours(5), Cache.NoSlidingExpiration);
        }

        private List<CartItem> GetItemsFromCache()
{
            var xml = (string)HttpRuntime.Cache.Get("Carrito");
            return Data.Services.Serializer.XmlToObject(xml);
        }

        public ActionResult Create(int id)
        {
            throw new NotImplementedException();
        }
    }
}
