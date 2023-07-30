using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Patrimonio.Entity
{
    public class dbContext : DbContext
    {
        public DbSet<Equipamento> Equipamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQL2019;Initial Catalog=ControleDePadrimonio;User ID=sa;Password=senha;TrustServerCertificate=True");
        }

        public static void insert<T>(T obj) where T : class
        {
            dbContext db = new dbContext();

            db.Add(obj);
            db.SaveChanges();
        }

        public static void update<T>(T obj) where T: class
        {
            dbContext db = new dbContext();
            db.SaveChanges();
        }

        public static T get<T>(int id) where T : class, new()
        {
            dbContext db = new dbContext();
            return db.Set<T>().Find(id) ?? new T();
        }

        public static List<T> getAll<T>() where T : class
        {
            dbContext db = new dbContext();
            return db.Set<T>().ToList();
        }

        public static void delete<T>(T obj) where T : class
        {
            dbContext db = new dbContext();
            db.Set<T>().Remove(obj);
        }
    }
}
