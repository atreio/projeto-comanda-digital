using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ComandaDigital.Models;
using AutoMapper;
using ComandaDigital.Dtos;
using ComandaDigital.Repositorio;
using ComandaDigital.Repositorio.Impl;
using ComandaDigital.Servicos;
using ComandaDigital.Servicos.Impl;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ComandaDigital
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => { options.LoginPath = "/Acesso/Index"; options.Cookie.Name = "vWebCookie"; });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ComandaDigitalContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("ComandaDigitalContext"), builder => builder.MigrationsAssembly("ComandaDigital")));

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<ICadastroUsuarioServico, CadastroUsuarioServico>();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioDto>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
