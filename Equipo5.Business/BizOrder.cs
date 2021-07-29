using Equipo5.Data.Services;
using System.Collections.Generic;
using Equipo5.Entities.Models;

namespace Equipo5.Business
{
    public class BizOrder
    {
        public void Agregar(Order order)
        {
            var db = new BaseDataService<Order>();
            db.Create(order);

        }

        public List<Order> TraerTodos()
        {
            var db = new BaseDataService<Order>();
            var lista = db.Get();
            return lista;
        }

        public Order TraerPorId(int id)
        {
            var db = new BaseDataService<Order>();
            return db.GetById(id);
        }

        public void Eliminar(Order order)
        {
            var db = new BaseDataService<Order>();
            db.Delete(order);
        }

        public void Actualizar(Order order)
        {
            var db = new BaseDataService<Order>();
            db.Update(order);
        }
    }
}
