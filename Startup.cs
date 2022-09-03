using Business.Implementations;
using Business.Interfaces;
using Lojinha3.Data.Repository.Generic;
using Lojinha3API.AutomapperConfig;
using Lojinha3API.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Lojinha3API
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
            //config conexão banco
            var connectionStrings = Configuration["ConnectionStrings:Mysql"];
            services.AddDbContext<LojinhaContext>(options => options.UseMySql(connectionStrings, ServerVersion.AutoDetect(connectionStrings)));

            //injeção de dependencia dos serviços

            //injeção das implementações da camada de negócios 
            services.AddTransient<IDesenvolvedoraBusiness, DesenvolvedoraBusinessImplementation>();

            //injeção do repositório genérico
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));


            services.AddAutoMapper(typeof(LojinhaProfile));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lojinha3API", Version = "v1" });
            });

          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lojinha3API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());

            app.UseAuthorization();

  
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
