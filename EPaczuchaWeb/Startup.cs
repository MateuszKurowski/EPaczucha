using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EPaczucha.database;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
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
            services.AddDbContext<EPaczuchaDbContext>(options => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EPaczuchaDatabase;Trusted_Connection=True;"));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<EPaczuchaDbContext>();
            services.AddControllersWithViews();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICrudRepository<User>, UserRepository>();
            services.AddScoped<ISendMethodRepository, SendMethodRepository>();
            services.AddScoped<ICrudRepository<SendMethod>, SendMethodRepository>();
            services.AddScoped<IPackagePriceRepository, PackagePriceRepository>();
            services.AddScoped<ICrudRepository<PackagePrice>, PackagePriceRepository>();
            services.AddScoped<IPackageTypeRepository, PackageTypeRepository>();
            services.AddScoped<ICrudRepository<PackageType>, PackageTypeRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<ICrudRepository<Package>, PackageRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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