using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project_ASP.Net.Models;
using Project_ASP.Net.Repositories;
using Project_ASP.Net.Repositories.Categories;

namespace Project_ASP.Net
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

            services.AddDbContext<ASPContext>(Options =>
            {
                Options.UseSqlServer(Configuration.GetConnectionString("cs"));
            });
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ASPContext>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IFilterPanelCategoriesRepository, FilterPanelCategoriesRepository>();
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ASPContext>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();

            ////// Sign Services 
            services.AddAuthentication()
            .AddGoogle(options =>
            {
                IConfigurationSection googleAuthSection = Configuration.GetSection("Authentication:Google");
                options.ClientId = googleAuthSection["ClientId"];
                options.ClientSecret = googleAuthSection["ClientSecret"];
            })
            .AddGitHub(gitHubOptions =>
            {
                gitHubOptions.ClientId = Configuration["Authentication:GitHub:ClientId"];
                gitHubOptions.ClientSecret = Configuration["Authentication:GitHub:ClientSecret"];

            })
            .AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            })
            ;

            services.AddControllersWithViews();

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

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
            app.UseAuthentication();

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
