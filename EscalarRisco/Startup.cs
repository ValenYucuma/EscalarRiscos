using EscalarRisco.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Xml.Linq;
using MediatR;
using System.Reflection;
using EscalarRisco.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;


namespace EscalarRisco
{
    public class Startup


    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddSingleton<List<Element>>(new List<Element>
    {
        new Element { Id = 1, Name = "E1", Weight = 5, Calories = 3 },
        new Element { Id = 2, Name = "E2", Weight = 3, Calories = 5 },
        new Element { Id = 3, Name = "E3", Weight = 5, Calories = 2 },
        new Element { Id = 4, Name = "E4", Weight = 1, Calories = 8 },
        new Element { Id = 5, Name = "E5", Weight = 2, Calories = 3 }
    });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Configurar manejo de errores en producción
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // Configura middleware para manejar la documentación de Swagger (si la tienes)
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Escalar Riscos");
            });

            // Configura middleware para permitir el enrutamiento y manejar solicitudes HTTP
            app.UseRouting();
            app.UseAuthorization();

            // Configura middleware para manejar los endpoints de controladores
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }

}