using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Propietaria2_2doRetro.Services;
using Propietaria2_2doRetro.Data;
using Propietaria2_2doRetro.Data.EfCore;
using Microsoft.OpenApi.Models;

namespace Propietaria2_2doRetro
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
            services.AddControllers();
            services.AddJWT(Configuration);
            services.AddAuthorization(config =>
            {
                config.AddPolicy(Policies.Admin, Policies.AdminPolicy());
                config.AddPolicy(Policies.User, Policies.UserPolicy());
            });
            //services.AddDbContext<DbContextMovies>(opt =>
            //    opt.UseSqlServer(Configuration.GetConnectionString("Conexion")));

            services.AddCors(opt =>
            {
                opt.AddPolicy("Todos",
                    builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*"));
            });

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Movie DB API",
                    Version = "v1",
                    Description = "Api del proyecto de Propietaria 2",
                    Contact = new OpenApiContact
                    {
                        Name = "Jesus Dicent ",
                        Email = "20181523@unapec.edu.do",
                        Url = new Uri("https://unapec.edu.do/"),
                    },
                });
            });


            services.AddDbContext<MDBContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MDBContext")));
            services.AddScoped<ActorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Todos");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieDB API");
            });
        }
    }
}
