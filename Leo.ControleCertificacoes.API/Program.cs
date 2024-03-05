using System.Reflection;

using Leo.ControleCertificacoes.API.Constants;
using Leo.ControleCertificacoes.Core.Application.DependencyInjection;

using Microsoft.OpenApi.Models;

namespace Leo.ControleCertificacoes.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string CorsPolicyName = "CorsPolicy";

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddCors(options =>
            {
            options.AddPolicy(name: CorsPolicyName,
                policy =>
                {
                    policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            builder.Services.Configure<RouteOptions>(opt => opt.LowercaseUrls = true);

            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc(ApiConstants.API_V1, new OpenApiInfo
                {
                    Version = ApiConstants.API_V1,
                    Title = ApiConstants.TITLE,
                    Description = ApiConstants.DESCRIPTION,
                    Contact = new OpenApiContact
                    {
                        Name = ApiConstants.AUTHOR,
                        Url = new Uri(ApiConstants.GITHUB_URL)
                    }
                });

                string xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
            });

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

            app.UseCors(CorsPolicyName);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
