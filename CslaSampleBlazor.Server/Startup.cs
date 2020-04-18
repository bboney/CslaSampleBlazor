using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Csla.Configuration;
using System.Globalization;
using CslaSampleBlazor.Dal.Common;
using CslaSampleBlazor.DalSql.Common;
using CslaSampleBlazor.Dal.Sales;
using CslaSampleBlazor.DalSql.Sales;
using CslaSampleBlazor.Dal.Security;
using Microsoft.AspNetCore.Authentication;
using CslaSampleBlazor.DalSql.Security;
using System.Net.Security;
using Csla.Data;
using Microsoft.Data.SqlClient;

namespace CslaSampleBlazor.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            string cn = Configuration["ConnectionStrings:CslaSampleBlazorDb"];
            ConfigurationManager.ConnectionStrings.Add("CslaSampleBlazorDb", new ConnectionStringSettings() { ConnectionString = cn });
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddTransient<IDivisionDal, DivisionDal>();
            services.AddTransient<ISalesOrderStatusDal, SalesOrderStatusDal>();
            services.AddTransient<ISalesOrderTypeDal, SalesOrderTypeDal>();
            services.AddTransient<INavigationDal, NavigationDal>();

            services.AddTransient((provider) =>
            {
                var result = ConnectionManager<SqlConnection>.GetManager(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString, false);
                return result;
            });

            services.AddHttpContextAccessor();
            services.AddCsla().WithBlazorServerSupport();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            app.UseCsla();
            Configuration.ConfigureCsla();

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
        }
    }
}
