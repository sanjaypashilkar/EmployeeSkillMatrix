using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SkillMatrix.Repository;
using SkillMatrix.Repository.DbConnector;
using SkillMatrix.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix
{
    public class Startup
    {
        #region Global Variables
        private IConfiguration _configuration { get; }
        private readonly string _connectionString = string.Empty;
        private readonly MySqlDbConnector _dbConnector; 


        #endregion
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SkillMatrixDb") ?? string.Empty;
            //_dbConnector = GetDatabaseConnector();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISkillMatrixRepository, SkillMatrixRepository>();
            services.AddTransient<ISkillMatrixService, SkillMatrixService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddMvc();
            services.AddControllersWithViews();
            ConfigureSkillMatrxServices(services);
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Report}/{action=Index}/{id?}");
            });
            app.UseNotyf();
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<SkillMatrixDb>();
                context.Database.Migrate();
            }
        }

        private void ConfigureSkillMatrxServices(IServiceCollection services)
        {
            services.AddTransient<ISkillMatrixRepository, SkillMatrixRepository>();
            //services.AddDbContext<SkillMatrixDb>(options => _dbConnector.GetDbContextOptions(options), ServiceLifetime.Transient);
            services.AddDbContext<SkillMatrixDb>(options => options.UseMySQL(_connectionString));
            services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });
        }
        private MySqlDbConnector GetDatabaseConnector()
        {
            var connectionFlag = _configuration.GetSection("AppSettings").GetValue<string>("DbConnectOption");
            return MySqlDbConnectorFactory.GetMySqlDbConnector(connectionFlag, _connectionString);
        }
    }
}
