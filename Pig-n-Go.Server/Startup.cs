using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pig_n_Go.BLL.Services;
using Pig_n_Go.DAL.DatabaseContexts;
using Pig_n_Go.DAL.Repositories;
using Pig_n_Go.Mappers.Order;

namespace Pig_n_Go
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
            services.AddControllersWithViews();
            services.AddDbContext<TaxiDbContext>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new OrderMapper());
                mc.AddProfile(new DriverMapper());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IOrderServiceAsync, OrderServiceAsync>();
            services.AddScoped<IDriverRepositoryAsync, DbDriverRepositoryAsync>();
            services.AddScoped<IPassengerRepositoryAsync, DbPassengerRepositoryAsync>();
            services.AddScoped<IOrderRepositoryAsync, DbOrderRepositoryAsync>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
}
