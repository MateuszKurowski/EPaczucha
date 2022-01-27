using System;

using EPaczucha.core;
using EPaczucha.database;

using EPaczuchaWeb.Authorization;

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
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EPaczuchaDbContext>(options => options
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EPaczuchaDatabase;Trusted_Connection=True;"));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<EPaczuchaDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddTransient<ICustomerRepository, UserRepository>();
            services.AddTransient<ISendMethodRepository, SendMethodRepository>();
            services.AddTransient<IPackagePriceRepository, PackagePriceRepository>();
            services.AddTransient<IPackageTypeRepository, PackageTypeRepository>();
            services.AddTransient<IPackageRepository, PackageRepository>();
            services.AddTransient<IDestinationRepository, DestinationRepository>();
            services.AddTransient<ICrudRepository<Package>, PackageRepository>();

            services.AddTransient<MapperDto>();
            services.AddTransient<MapperViewModel>();
            services.AddTransient<IManagerDto, ManagerDto>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            });

            //services.AddSingleton<BasicAuthorizationFilter>();
            //services.AddMvc().AddMvcOptions(options =>
            //{
            //    options.Filters.AddService<BasicAuthorizationFilter>();
            //});
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
                    name: "paczki",
                    pattern: "paczki/lista",
                    defaults: new { controller = "Packages", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=HomePage}/{id?}");
                endpoints.MapRazorPages();
            });

            serviceProvider.GetService<EPaczuchaDbContext>().Database.Migrate();
        }
    }
}