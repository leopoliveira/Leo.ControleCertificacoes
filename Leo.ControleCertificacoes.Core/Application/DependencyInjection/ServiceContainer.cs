using Leo.ControleCertificacoes.Core.Infra.AppDbContext;
using Leo.ControleCertificacoes.Core.Repository.Implementation;
using Leo.ControleCertificacoes.Core.Repository.Interfaces;
using Leo.ControleCertificacoes.Core.Services.Implementation;
using Leo.ControleCertificacoes.Core.Services.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Leo.ControleCertificacoes.Core.Application.DependencyInjection
{
    public static class ServiceContainer
    {
        public static void AddDbContextService(this IServiceCollection service)
        {
            const string connectionString = @"Database\Certificados.db";
            service.AddDbContext<AppDbContext>(options => options.UseSqlite(string.Format("Data Source={0}", connectionString)));
        }

        public static void AddRepositoryServices(this IServiceCollection service)
        {
            service.AddScoped<IEmployeeRepository, EmployeeRepository>();
            service.AddScoped<ICertifiedRepository, CertifiedRepository>();
        }

        public static void AddAppServices(this IServiceCollection service)
        {
            service.AddScoped<IEmployeeService, EmployeeService>();
            service.AddScoped<ICertifiedService, CertifiedService>();
        }
    }
}
