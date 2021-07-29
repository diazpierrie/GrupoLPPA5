using Equipo5.Data.Services;
using Equipo5.Entities.Models;
using System.Collections.Generic;

namespace Equipo5.Business
{
    public class BizProducto
    {
        public void Agregar(Product producto)
        {
            var db = new BaseDataService<Product>();
            db.Create(producto);

        }
        public List<Product> TraerTodos()
        {
            var db = new BaseDataService<Product>();
            var lista = db.Get();
            return lista;
        }

        public Product TraerPorId(int id)
        {
            var db = new BaseDataService<Product>();
            return db.GetById(id);
        }

        public void Eliminar(Product producto)
        {
            var db = new BaseDataService<Product>();
            db.Delete(producto);
        }
        public void Eliminar(int idProducto)
        {
            var db = new BaseDataService<Product>();
            db.Delete(idProducto);
        }

        public void Actualizar(Product producto)
        {
            var db = new BaseDataService<Product>();
            db.Update(producto);
        }
    }
}
