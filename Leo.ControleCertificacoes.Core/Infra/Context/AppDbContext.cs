using Leo.ControleCertificacoes.Core.Domain.Entities;
using Leo.ControleCertificacoes.Core.Infra.Contecertifiedt.Configuration;
using Leo.ControleCertificacoes.Core.Infra.Context.Configuration;

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
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder.ApplyConfiguration(new CertifiedConfiguration());

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                DataSeed(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }

        private static void DataSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = new Guid("E1E7E405-4690-42E8-8423-DD9ECD389BC7"),
                Code = 1,
                Name = "Employee 1",
                Department = "HR",
                NumberOfCertifieds = 1
            });

            var today = DateTime.Now;

            modelBuilder.Entity<Certified>().HasData(new Certified
            {
                Id = new Guid("A4679709-46FC-4FE4-92BC-B227354ABAA7"),
                Code = 1,
                Name = "Certified 1",
                Expiration = new DateOnly(today.Year, today.Month, today.Day),
                Description = "Certified 1 Description",
                EmployeeId = new Guid("E1E7E405-4690-42E8-8423-DD9ECD389BC7")
            });
        }
    }
}
