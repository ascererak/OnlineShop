using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebShopTutorial.Data;
using WebShopTutorial.Data.Interfaces;
using WebShopTutorial.Data.Mocks;
using WebShopTutorial.Data.Models;
using WebShopTutorial.Data.Repositories;

namespace WebShopTutorial
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private IConfigurationRoot configurationRoot;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configurationRoot.GetConnectionString("DefaultConnection")));
            services.AddTransient<IDeviceRepository, DeviceRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            DbInitializer.Seed(app);

            //app.Run(async (context) =>
            //{
                //await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
