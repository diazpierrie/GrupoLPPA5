using Equipo5.Data.Services;
using System.Collections.Generic;
using Equipo5.Entities.Models;

namespace Equipo5.Business
{
    public class BizCarrito
    {
        public Cart Agregar(Cart carrito)
        {
            var db = new BaseDataService<Cart>();
            return db.Create(carrito);
        }

        public List<Cart> TraerTodos()
        {
            var db = new BaseDataService<Cart>();
            var lista = db.Get();
            return lista;
        }

        public Cart TraerPorId(int id)
        {
            var db = new BaseDataService<Cart>();
            return db.GetById(id);
        }

        public void Eliminar(Cart carrito)
        {
            var db = new BaseDataService<Cart>();
            db.Delete(carrito);
        }

        public void Actualizar(Cart carrito)
        {
            var db = new BaseDataService<Cart>();
            db.Update(carrito);
        }

        public void AgregarCartItem(CartItem CartItem)
        {
            var db = new BaseDataService<CartItem>();
            db.Create(CartItem);
        }
    }
}
