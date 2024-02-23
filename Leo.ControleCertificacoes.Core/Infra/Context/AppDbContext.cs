using Leo.ControleCertificacoes.Core.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Leo.ControleCertificacoes.Core.Infra.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Certified> Certifieds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
