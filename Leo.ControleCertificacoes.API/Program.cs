using Leo.ControleCertificacoes.Core.Application.DependencyInjection;
using Leo.ControleCertificacoes.Core.Repository.Implementation;
using Leo.ControleCertificacoes.Core.Repository.Interfaces;

namespace Leo.ControleCertificacoes.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DbContext Injection
            builder.Services.AddDbContextService();

            builder.Services.AddRepositoryServices();

            builder.Services.AddAppServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
