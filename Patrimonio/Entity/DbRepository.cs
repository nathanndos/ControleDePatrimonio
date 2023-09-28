using Patrimonio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Entity
{
    public abstract class DbRepository<T> where T : class, new()
    {
        public Expression<Func<T, T>> select;
        public Expression<Func<T, bool>> where;
        public Expression<Func<T, string>> orderBy;

        public void insert(T obj)
        {
            dbContext.get.Add(obj);
            dbContext.get.SaveChanges();
        }

        public void update(T obj) => dbContext.get.SaveChanges();

        public T get(int id) => dbContext.get.Set<T>().Find(id) ?? new T();

        public List<T> getAll() => dbContext.get.Set<T>().ToList();

        public void delete(T obj) => dbContext.get.Set<T>().Remove(obj);

        public List<T> list() => dbContext.get.Set<T>().Where(where).OrderBy(orderBy).Select(select).ToList();
    }
}
