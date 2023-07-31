using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Patrimonio.Entity
{
    public class dbContext : DbContext
    {
        private static dbContext? instance;
        public static dbContext Instance
        {
            get
            {
                if (instance is null)
                    instance = new dbContext();

                return instance;
            }
        }

        public DbSet<Equipamento> Equipamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQL2019;Initial Catalog=ControleDePadrimonio;User ID=sa;Password=senha;TrustServerCertificate=True");
        }

        public void insert<T>(T obj) where T : class
        {
            Instance.Add(obj);
            Instance.SaveChanges();
        }

        public void update<T>(T obj) where T : class => Instance.SaveChanges();

        public T get<T>(int id) where T : class, new() => Instance.Set<T>().Find(id) ?? new T();

        public List<T> getAll<T>() where T : class => Instance.Set<T>().ToList();

        public void delete<T>(T obj) where T : class => Instance.Set<T>().Remove(obj);
    }
}
