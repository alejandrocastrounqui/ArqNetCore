using System.Threading.Tasks;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            services.AddCors();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<ArqNetCoreDbContext>(
                (DbContextOptionsBuilder options) => 
                {
                    options.UseMySQL(
                        "server=localhost;database=dbnetcore;user=netcoreuser;password=netcorepass", 
                        (MySQLDbContextOptionsBuilder builder) => 
                        {
                            builder.ExecutionStrategy(context => {
                                return new ArqNetDbExecutionStrategy(context);
                        });
                });
            });

            services.AddControllers();
            services.AddSwaggerDocument();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAuthService, AuthService>();
            
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer((JwtBearerOptions jwtBearerOptions) =>
            {
                jwtBearerOptions.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        //it is not necesary due token should be signed 
                        // var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        // var email = context.Principal.Identity.Name;
                        // var user = userService.GetByEmail(email);
                        // if (user == null)
                        // {
                        //     // return unauthorized if user no longer exists
                        //     // TODO: improve log description 
                        //     context.Fail("Unauthorized");
                        // }
                        return Task.CompletedTask;
                    }
                };
                jwtBearerOptions.RequireHttpsMetadata = false;
                jwtBearerOptions.SaveToken = true;
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

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
