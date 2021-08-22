using MapleCore.Interfaces;
using MapleCore.MiddleWare;
using MapleData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;

namespace MapleWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Use the below commented line is to encrypt the connection string and add the ecrypted connection string in appsettings.
            //var encryptDB = MapleCore.Utilities.Encrypt("Host=localhost;Port=5432;Database=Maple;Username=postgres;Password=P@ssw0rd");
            string dbName = _configuration["ConnectionString:pstgres"];
            if (string.IsNullOrEmpty(dbName))
                return;
            var conString = MapleCore.Utilities.Decrypt(dbName);
            services.AddDbContext<AppDBContext>(options =>
                options.UseNpgsql(conString));
            services.AddControllers();
            services.AddTransient<IRepository, EFRepository>();
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(_configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
            });

            // Register the Swagger services
            if (_configuration["AppSettings:ApiHelp"] == "Y")
                services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Register the Swagger generator and the Swagger UI middlewares
            if (_configuration["AppSettings:ApiHelp"] == "Y")
            {
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            app.UseRouting();
            app.UseMiddleware<ExceptionMiddleWare>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
