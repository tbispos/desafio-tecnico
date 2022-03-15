using Domain.Interface.Service;
using Domain.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interface.Repository;
using Domain.Context;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using BACK.Middlewares;
using Domain.Interface.Login;
using Domain.Login;

namespace BACK
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
            // EF In Memory
            services.AddScoped<ICardService, CardService>()
                .AddScoped<ICardRepository, CardRepository>()
                .AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("dbmemory"));

            // AutoMapper
            services.AddAutoMapper(typeof(Startup));

            // Interfaces das Services
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ISigningConfigurations, SigningConfigurations>();

            // Interfaces dos Repositórios
            services.AddScoped<ICardRepository, CardRepository>();

            //Controllers
            services.AddControllers();

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BACK", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BACK v1"));
            }

            app.UseCors(config =>
            {
                config.AllowAnyOrigin();
                config.AllowAnyHeader();
                config.AllowAnyMethod();

            });

            app.UseHttpsRedirection();
            app.UseMiddleware<Middleware>();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
