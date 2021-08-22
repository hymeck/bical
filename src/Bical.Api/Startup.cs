using System.Reflection;
using Bical.Api.Persistence.Contexts;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bical.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddFluentValidation(fvOptions =>
                    fvOptions.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()))
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddDbContext<BicalDbContext>(dbOptions =>
                    dbOptions.UseMySql(Configuration.GetConnectionString("Mysql"), new MySqlServerVersion(Configuration["DbVersionStrings:Mysql"])))
                .AddScoped<IApplicationDbContext>(provider => provider.GetService<BicalDbContext>());

            services
                .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
