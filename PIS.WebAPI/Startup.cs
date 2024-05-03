using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PIS.DAL.DataModel;
using PIS.Repository.Automapper;
using PIS.Repository.Common;

namespace PIS.WebAPI
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

            services.AddDbContext<PIS_DbContext>(options =>
            options.EnableSensitiveDataLogging().UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), 
            b => b.MigrationsAssembly("PIS.WebAPI")), ServiceLifetime.Singleton);

            //  Service layer
            services.AddScoped<IService, Service.Service>();

            // Repository layer
            services.AddSingleton<IRepository, Repository.Repository>();

            //mapping service
            services.AddSingleton<IRepositoryMappingService, RepositoryMappingService>();

            services.AddCors();
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
