using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Motorista.Infra.CrossCutting.IoC;
using Motorista.Infra.Data.Context;
using Motorista.WebApi.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace Motorista.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MotoristaContext>(cfg => {
                cfg.UseSqlServer(Configuration.GetConnectionString("MotoristaConnectionString"),
                    b => b.MigrationsAssembly("Motorista.App"));
            });

            services.AddAutoMapperSetup();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v2",
                    new Info {
                        Title = "API de motoristas",
                        Version = "v2",
                        Description = "API de motorista",
                        Contact = new Contact {
                            Name = "Reinaldo Bispo"
                        }
                    });

                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
            
            DependencyResolver.RegisterServices(services);
            HttpClientFactory.RegisterServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v2/swagger.json",
                    "API de Motoristas");
            });

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
