using EmployeeManagementSystem.Repositories;
using EmpManagement.Domain;
using EmpManagement.Domain.Models;
using EmpManagement.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.API
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
            var connectionString = Configuration.GetConnectionString("connectionString");

            services.AddControllers();
            services.AddTransient<ILeaveRepositorys, LeaveService>();
            services.AddTransient<ITicketRepositorys, TicketService>();
            services.AddDbContext<KumaravelContext>(context => context.UseSqlServer(connectionString)); //Dependency injection
           // services.addDataAccess<ApplyLeaveDbContext>();
            services.AddCors();// cors service
            services.AddSwaggerGen(
                options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Leave Microservice",
                    Description = "Leave authentication",
                    Version = "v1"
                });
                //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                //{
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer",
                //    BearerFormat = "Jwt",
                //    In = ParameterLocation.Header,
                //    Description = "Jwt token for authorized user"
                //});
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {new OpenApiSecurityScheme(){Reference=new OpenApiReference{ Id="Bearer", Type=ReferenceType.SecurityScheme}}, new string[]{ } }
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
                //  endpoints.Expand().Select().Filter().OrderBy().Count().MaxTop(100);
                // endpoints.MapRazorPages();

            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Leave Microservice");
            });

           

          

        }
    }
}
