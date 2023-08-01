using Microsoft.EntityFrameworkCore;

namespace Patrimonio.Entity
{
    public class dbContext : DbContext
    {
        private static dbContext? Context;

        public static dbContext get
        {
            get
            {
                if (Context is null)
                    Context = new dbContext();

                return Context;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source=localhost\\SQL2019;Initial Catalog=ControleDePadrimonio;User ID=sa;Password=senha;TrustServerCertificate=True");

        public DbSet<Equipamento> Equipamento { get; set; }
    }
}
