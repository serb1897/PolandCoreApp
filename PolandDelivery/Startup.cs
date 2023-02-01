using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PolandDelivery.FileLogger;
using PolandDelivery.Interfaces;
using PolandDelivery.Middlewares;
using PolandDelivery.Models;
using PolandDelivery.Models.DBModels;
using System;

namespace PolandDelivery
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            Action<AppSettings> appSettings = opt =>
            {
                opt.connectionString = connection;
                opt.sliderNewsNumber = Configuration.GetValue<int>("SliderNewsNumber");
                opt.newsAtPageNumber = Configuration.GetValue<int>("NewsAtPageNumber");
                opt.bannersNumber = Configuration.GetValue<int>("BannersNumber");
                opt.logPath = Configuration.GetValue<string>("LogPath");
                opt.initDB = Configuration.GetValue<bool>("InitDB");
            };
            services.Configure(appSettings);
            
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddErrorDescriber<CustomIdentityErrorDescriber>();

            //Логирование. FileLoggerProvider - в файл, DBLoggerProvider в базу данных
            //services.AddTransient<ILoggerProvider, DBLoggerProvider>();
            services.AddTransient<ILoggerProvider, FileLoggerProvider>();

            services.AddTransient<IDBOperationRepository, ApplicationDBOperationsDapper>();
            services.AddTransient<IGenericPages, GenericPagesModel>();
            services.AddTransient<IMenu, MenuModel>();
            services.AddTransient<INews, NewsModel>();
            services.AddTransient<IUserForms, UserFormsModel> ();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Home/NotAccess";
            });
            services.AddAuthentication().AddCookie();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Проверка существования страницы и редирект на 404
            app.UsePageNotFound();

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
            });

        }
    }
}
