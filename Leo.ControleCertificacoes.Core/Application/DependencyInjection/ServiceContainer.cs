using Leo.ControleCertificacoes.Core.Infra.AppDbContext;

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
    }
}
