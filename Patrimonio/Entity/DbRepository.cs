using System;
using System.Collections.Generic;
using System.Linq;

namespace Patrimonio.Entity
{
    public class DbRepository<T> where T : class, new()
    {
        public static void insert(T obj)
        {
            dbContext.get.Add(obj);
            dbContext.get.SaveChanges();
        }

        public static void update(T obj) => dbContext.get.SaveChanges();

        public static T get(int id) => dbContext.get.Set<T>().Find(id) ?? new T();

        public static List<T> getAll() => dbContext.get.Set<T>().ToList();

        public static void delete(T obj) => dbContext.get.Set<T>().Remove(obj);
    }
}
