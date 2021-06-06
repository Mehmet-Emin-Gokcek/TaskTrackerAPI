using TaskTrackerAPI.Data;
using TaskTrackerAPI.Models;
using TaskTrackerAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerAPI
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

            //ASP.NET Core provides an instance of TaskRepository class when an instance of ITaskRepository is requested.
            //We are using AddScoped() method because we want the instance to be alive and available for the entire
            //scope of the given HTTP request. For another new HTTP request, a new instance of TaskRepository
            //class will be provided and it will be available throughout the entire scope of that HTTP request.
            services.AddScoped<IUserTaskRepository, UserTaskRepository>();

            /*            services.AddDbContext<UserTaskContext> (options =>
                           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));*/

                        services.AddDbContext<UserTaskContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("AzureDbConnection")));

            services.AddSingleton<UserTaskService>();

            services.AddCors(options =>
            {
                    options.AddPolicy("ReactPolicy",
                        builder =>
                        {
                            builder.WithOrigins("https://mehmetgokcek.github.io")
                                   .AllowAnyHeader()
                                   .AllowAnyMethod();
                        });
            });
            services.AddControllers();
            services.AddRazorPages();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors();

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
