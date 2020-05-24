using System;
using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using WebApi.Helpers;
using WebApi.Repository;
using WebApi.Repository.Interfaces;
using WebApi.Services;
using WebApi.Services.Interfaces;
using WebApiLogger;

namespace WebApi
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
            LogManager.LoadConfiguration(Path.Combine(Directory.GetCurrentDirectory(), "nlog.config"));
          
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // use sql server db in production or in development
            if (_env.IsProduction())
                services.AddDbContext<DataContext>();
            else
                services.AddDbContext<DataContext>();

            services.AddCors();
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // configure strongly typed settings objects
            var appSettingsSection = _configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            services.AddTransient<IUserRepository<Entities.User>, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<ITodoTaskRepository<Entities.TodoTask>, TodoTaskRepository>();
            services.AddTransient<ITodoTaskService, TodoTaskService>();

            services.AddSingleton<ILoggerWebApi, LoggerWebApi>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext)
        {
            // migrate any database changes on startup (includes initial db creation)
            dataContext.Database.Migrate();

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCustomLogger();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
