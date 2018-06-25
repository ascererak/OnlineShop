using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiflexersShop.Models.Data;
using MultiflexersShop.Models.Entities;
using MultiflexersShop.Models.Interfaces;
using MultiflexersShop.Models.Repositories;

namespace MultiflexersShop
{
    public class Startup
    {
        //private IConfigurationRoot configuration;
        public IConfiguration Configuration { get; }

        public Startup(/*IConfiguration configuration*/IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            //configuration = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
            //    .AddJsonFile($"appsettings.production.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Сonfiguration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddTransient<IDeviceRepository, DeviceRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));


            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseIdentity();

            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "categoryFilter", template: "Device/{action}/{category?}", defaults: new { Controller = "Device", action = "List" });
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
