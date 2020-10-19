using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Hermoza.BibloMax.Datos.Infraestructura.Conexiones;
using Hermoza.BibloMax.Datos.Infraestructura.Contextos;
using Hermoza.BibloMax.Integracion.Infraestructura.Autofac;
using Hermoza.BibloMax.Servicios.General.Dtos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Hermoza.BibloMax.Integracion
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                
                .AddJsonFile("configuraciones.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SOContexto>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SO")));
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper();
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Principal/SOLogin", "")
                .AddPageRoute("/Principal/SOIndex", "/Index");
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var builder = new ContainerBuilder();
            builder.Populate(services);

            cargarDatosConfiguracion(builder);

            builder.RegisterModule(new RepositoriosModule());
            builder.RegisterModule(new ServiciosModule());

            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        private void cargarDatosConfiguracion(ContainerBuilder builder)
        {
            builder.Register(c => new SOConnection() { StringConnection = Configuration.GetConnectionString("SO") }).InstancePerLifetimeScope();

            builder.Register(c => new AppConfiguracionesDto()
            {
                RutaTemplateRecuperarContrasenia = Configuration["Template:RUTA_TEMPLATE_PARA_ENVIAR_CORREOS"],
                PassworSalt = Configuration["Valores:PASSWORD_SALT"]
            }).InstancePerLifetimeScope();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc();
        }
    }
}
