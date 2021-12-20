using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Proyecto1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1
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
            services.AddControllersWithViews();

            //conexion 
            string BaseDatos = Configuration.GetSection("Parametros").GetSection("BaseDatos").Value;
            if (BaseDatos == "SqlServer")
            {
                string conn = Configuration.GetConnectionString("ConnDbSqlServer");
                services.AddDbContext<DBEmpresa>(options => options.UseSqlServer(conn));
            }
            if (BaseDatos == "Postgres")
            {
                string connPostgres = Configuration.GetConnectionString("ConnDbPostgres");
                services.AddDbContext<DBEmpresa>(options => options.UseNpgsql(connPostgres));
            }
            if (BaseDatos == "Memory")
            {
                
                services.AddDbContext<DBEmpresa>(options => options.UseInMemoryDatabase(databaseName:"DBMemoria"));
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
