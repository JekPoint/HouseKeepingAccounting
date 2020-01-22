using HouseKeepingAccounting.MVC.HouseData;
using HouseKeepingAccounting.MVC.HouseData.Interfaces;
using HouseKeepingAccounting.MVC.HouseServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HouseKeepingAccounting.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            SqliteConnection connection = new SqliteConnection(new SqliteConnectionStringBuilder() { DataSource = "HouseData.db" }.ToString());
            connection.OpenAsync().Wait();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(options => { options.EnableEndpointRouting = false; })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddScoped<IHouseAssets, HouseService>();
            services.AddDbContext<HouseContext>(options=> 
                options.UseSqlite("Data Source = HouseData.db")
                    .ConfigureWarnings(c=>c.Log((RelationalEventId.CommandExecuting, LogLevel.Debug))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=House}/{action=Index}/{id?}");
            });
        }
    }
}
