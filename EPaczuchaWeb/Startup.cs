using System;

using EPaczucha.core;
using EPaczucha.database;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EPaczuchaWeb
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
            services.AddDbContext<EPaczuchaDbContext>(options => options
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EPaczuchaDatabase;Trusted_Connection=True;"));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<EPaczuchaDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            //services.AddTransient<ICustomerRepository, CustomerRepository>();
            //services.AddTransient<ISendMethodRepository, SendMethodRepository>();
            //services.AddTransient<IPackagePriceRepository, PackagePriceRepository>();
            //services.AddScoped<IPackageTypeRepository, PackageTypeRepository>();
            //services.AddTransient<IPackageRepository, PackageRepository>();
            //services.AddTransient<IDestinationRepository, DestinationRepository>();
            //services.AddTransient<ICrudRepository<Package>, PackageRepository>();

            //services.AddTransient<MapperDto>();
            //services.AddTransient<MapperViewModel>();
            //services.AddScoped<IManagerDto, ManagerDto>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            serviceProvider.GetService<EPaczuchaDbContext>().Database.Migrate();
        }
    }
}