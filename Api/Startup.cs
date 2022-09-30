using Business.Implementations;
using Business.Interfaces;
using Lojinha3.Business.Implementations;
using Lojinha3.Business.Interfaces;
using Lojinha3.Configurations;
using Lojinha3.Data.Repository;
using Lojinha3.Data.Repository.Generic;
using Lojinha3.Data.Repository.Implementations;
using Lojinha3.Service.Interfaces;
using Lojinha3.Service.Service;
using Lojinha3API.AutomapperConfig;
using Lojinha3API.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Text;

namespace Lojinha3API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
            //Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var tokenConfigurations = new TokenConfiguration();

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                Configuration.GetSection("TokenConfigurations")).Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenConfigurations.Issuer,
                    ValidAudience = tokenConfigurations.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurations.Secret))
                };
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options => 
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //config conexão banco
            var connectionStrings = Configuration["ConnectionStrings:Mysql"];
            services.AddDbContext<LojinhaContext>(options => options.UseMySql(connectionStrings, ServerVersion.AutoDetect(connectionStrings)));

            //injeção de dependencia dos serviços

            //injeção das implementações da camada de negócios 
            services.AddTransient<IDesenvolvedoraBusiness, DesenvolvedoraBusinessImplementation>();
            services.AddTransient<ICategoriaMenuAcessoBussiness, CategoriaMenuAcessoBusinessImplementation>();
            services.AddTransient<ILoginBusiness, LoginBusinessImplementation>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUsuarioBusiness, UsuarioBusinessImplementation>();
            services.AddTransient<IPermissaoUsuarioBusiness, PermissaoUsuarioBusinessImplementation>();


            //injeção do repositório genérico
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            //injeção do repositório de usuario
            services.AddScoped<IUserRepository, UserRepository>();


            services.AddAutoMapper(typeof(LojinhaJogosProfile), typeof(LojinhaAccessProfile));

            services.AddControllers();

            //Configuração do swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                    new OpenApiInfo
                    {
                        Title = "Lojinha3 Agora VAI!!!!",
                        Version = "v1",
                        Description = "Api para testes de arquitetura, frontent e mais loucuras que o dev decidir",
                        Contact = new OpenApiContact
                        {
                            Name = "Alexsander (Sander's) Cordeiro",
                            Url = new Uri("https://github.com/Alex-cordeiro"),
                            Email = "alexsandercordeiroalves@gmail.com"
                        }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lojinha3 AGORA VAI!"));
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
