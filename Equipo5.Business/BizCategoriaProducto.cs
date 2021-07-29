using Equipo5.Data.Services;
using System.Collections.Generic;
using Equipo5.Entities.Models;

namespace Equipo5.Business
{
    public class BizCategory
    {
        public void Agregar(Category categoriaProducto)
        {
            var db = new BaseDataService<Category>();
            db.Create(categoriaProducto);

        }

        public List<Category> TraerTodos()
        {
            var db = new BaseDataService<Category>();
            var lista = db.Get();
            return lista;
        }

        public Category TraerPorId(int id)
        {
            var db = new BaseDataService<Category>();
            return db.GetById(id);
        }

        public void Eliminar(Category categoriaProducto)
        {
            var db = new BaseDataService<Category>();
            db.Delete(categoriaProducto);
        }

        public void Eliminar(int idCategory)
        {
            var db = new BaseDataService<Category>();
            db.Delete(idCategory);
        }

        public void Actualizar(Category categoriaProducto)
        {
            var db = new BaseDataService<Category>();
            db.Update(categoriaProducto);
        }
    }
}
