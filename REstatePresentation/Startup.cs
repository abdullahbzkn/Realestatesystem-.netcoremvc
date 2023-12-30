using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace REstatePresentation
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
            services.AddScoped<IServiceHousingService, ServiceHousingManager>();
            services.AddScoped<IServiceHousingDal, EfServiceHousingDal>();
            services.AddScoped<IServicePhotoService, ServicePhotoManager>();
            services.AddScoped<IServicePhotoDal, EfServicePhotoDal>();
            services.AddScoped<IServiceMapService, ServiceMapManager>();
            services.AddScoped<IServiceMapDal, EfServiceMapDal>();
            services.AddScoped<IServiceInfoService, ServiceInfoManager>();
            services.AddScoped<IServiceInfoDal, EfServiceInfoDal>();
            services.AddScoped<IServiceTerrainService, ServiceTerrainManager>();
            services.AddScoped<IServiceTerrainDal, EfServiceTerrainDal>();
            services.AddScoped<ITeamService, TeamManager>();
            services.AddScoped<ITeamDal, EfTeamDal>();


            services.AddDbContext<REstateContext>();
            services.AddControllersWithViews();
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
                app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

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
