using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using pizzaWorld.Extensions;
using pizzaWorld.Models;
using pizzaWorld.PizzaWorldDbContext;
using pizzaWorld.Repositories;
using pizzaWorld.Settings;

namespace pizzaWorld
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<PizzaWorldContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<PizzaWorldContext>()
                .AddDefaultTokenProviders();

            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));

            var jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();

            services.AddSwagger();

            services.AddAuth(jwtSettings);

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<ILivreurRepository, LivreurRepository>();
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<IScooterRepository, ScooterRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseSwaggerAsHome();

            app.UseRouting();

            app.UseAuth();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
