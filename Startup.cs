using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Infrastructure;
using AutoMapper;
using ArqNetCore.Configuration;
using ArqNetCore.Services;

namespace ArqNetCore
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
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<ArqNetCoreDbContext>(
                (DbContextOptionsBuilder options) => {
                options.UseMySQL(
                    "server=localhost;database=dbnetcore;user=netcoreuser;password=netcorepass", 
                    (MySQLDbContextOptionsBuilder builder) => {
                        builder.ExecutionStrategy(context => {
                            return new ArqNetDbExecutionStrategy(context);
                        });
                    }
                );
            });

            services.AddControllers();
            services.AddSwaggerDocument();
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
