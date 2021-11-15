using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SkillMatrix.Repository;
using SkillMatrix.Repository.DbConnector;
using SkillMatrix.Service;

namespace SkillMatrix
{
    public class Startup
    {
        #region Global Variables
        private IConfiguration _configuration { get; }
        private readonly string _connectionString = string.Empty;


        #endregion
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SkillMatrixDb") ?? string.Empty;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISkillMatrixRepository, SkillMatrixRepository>();
            services.AddTransient<ISkillMatrixService, SkillMatrixService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IAttributeService, AttributeService>();
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
            var serverVersion = ServerVersion.AutoDetect(_connectionString);
            services.AddDbContext<SkillMatrixDb>(options => options.UseMySql(_connectionString, serverVersion));
        }
        private MySqlDbConnector GetDatabaseConnector()
        {
            var connectionFlag = _configuration.GetSection("AppSettings").GetValue<string>("DbConnectOption");
            return MySqlDbConnectorFactory.GetMySqlDbConnector(connectionFlag, _connectionString);
        }
    }
}
