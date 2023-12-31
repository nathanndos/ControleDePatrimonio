﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Entity
{
    public abstract class DbRepository<T> where T : EntityBase, new()
    {
        public Expression<Func<T, T>> select { get; set; }
        public Expression<Func<T, bool>> where { get; set; }
        public Expression<Func<T, string>> orderBy { get; set; }
        public Expression<Func<T, bool>> exist { get; set; }

        public void insert(T obj)
        {
            dbContext.get.Add(obj);
            dbContext.get.SaveChanges();
        }

        public void update(T obj) => dbContext.get.SaveChanges();

        public T get(int id) => dbContext.get.Set<T>().Find(id) ?? new T();

        public T get(Guid ide) => dbContext.get.Set<T>().FirstOrDefault(i => i.Ide.Equals(ide)) ?? new T();

        public List<T> getAll() => dbContext.get.Set<T>().ToList();

        public void delete(T obj) => dbContext.get.Set<T>().Remove(obj);

        public List<T> list() => dbContext.get.Set<T>().Where(where).OrderBy(orderBy).Select(select).ToList();

        public bool exists() => dbContext.get.Set<T>().Any(exist);
        public bool notExists() => !exists();
    }
}
