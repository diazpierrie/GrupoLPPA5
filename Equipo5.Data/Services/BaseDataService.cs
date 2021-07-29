using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using Equipo5.Entities.Models;

namespace Equipo5.Data.Services
{
    public class BaseDataService<T> : IDataService<T> where T : Entities.Models.IdentityBase, new()
    {
        protected Equipo5DbContext equipo5Context;

        public BaseDataService()
        {
            this.equipo5Context = new Equipo5DbContext();
        }

        public T Create(T entity)
        {
            equipo5Context.Set<T>().Add(entity);
            equipo5Context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            equipo5Context.Set<T>().Attach(entity);
            equipo5Context.Set<T>().Remove(entity);
            equipo5Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            this.Delete(entity);
        }

        public List<T> Get(Expression<Func<T, bool>> whereExpression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunction = null, string includeModels = "")
        {
            IQueryable<T> query = equipo5Context.Set<T>();

            if (whereExpression != null)
                query = query.Where(whereExpression);

            var entity = includeModels.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            query = entity.Aggregate(query, (current, model) => current.Include(model));

            if (orderFunction != null)
                query = orderFunction(query);

            return query.ToList();
        }

        public T GetById(int id)
        {
            return equipo5Context.Set<T>().SingleOrDefault(o => o.Id == id);
        }

        public void Update(T entity)
        {
            equipo5Context.Entry(entity).State = EntityState.Modified;
            equipo5Context.SaveChanges();
        }

        public List<ValidationResult> ValidateModel(T model)
        {
            throw new NotImplementedException();
        }
    }
}