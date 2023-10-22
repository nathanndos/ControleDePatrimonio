using Microsoft.EntityFrameworkCore;

namespace Entity
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipamento>().Property(i => i.Nome).HasColumnType("varchar").HasMaxLength(100);
        }

        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }
    }
}
