using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CreaFormDemo.DtoModel;
using CreaFormDemo.Entitys;
using CreaFormDemo.Entitys.Users;
using CreaFormDemo.Repository;
using CreaFormDemo.Services;
using CreaFormDemo.Services.Data;
using CreaFormDemo.Services.IRepository;
using CreaFormDemo.Services.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace CreaFormDemo
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
            services.AddControllers().AddNewtonsoftJson(options =>
            
options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
           
            services.AddDbContext<CreaFormDBcontext>
               (options => options.UseSqlServer(Configuration.GetConnectionString("Connst")));
            services.AddScoped<IAuthRepository,AuthRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAdvisorRepository, AdvisorRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ISymtomRepo, SymtomRepo>();

            services.AddTransient<SeedData>();
            services.AddAutoMapper(typeof(CreaFormProfile));


            //ADD Swagger
            services.AddSwaggerGen(Options =>
            {
                Options.SwaggerDoc("CreaFormOpenAPISpec", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "CreaForm API",
                    Version = "1",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email = "bahaa.abokhaled83@gmail.com",
                        Name = "Bahaa Abo Khaled"
                    },
                    Description = "CreaForm API"
                });
                //För att visa beskrivningen relaterad till varje metod i kontrollen
                var Xmlcommentfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlcommentFullPath = Path.Combine(AppContext.BaseDirectory, Xmlcommentfile);
                Options.IncludeXmlComments(xmlcommentFullPath);

                //JWT tokens inside a swagger.
                Options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description =
                "Jwt Authorization header using the Bearer schema.\r\n\r\n Enter 'Bearer '[mellanslag] och sedan din token i textinmatningen nedan ",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                Options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        { new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            },
                            Scheme="oauth2",
                            Name="Bearer",
                            In=ParameterLocation.Header,
                        },
                        new List<string>()

                        }

                    });

            });
            //add Authonticat 

            var appsettingsection = Configuration.GetSection("Appsettings");
            services.Configure<Appsettings>(appsettingsection);
            var appsettings = appsettingsection.Get<Appsettings>();
            var Key = Encoding.ASCII.GetBytes(appsettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(X =>
            {
                X.RequireHttpsMetadata = false;
                X.SaveToken = true;
                X.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            

        }
        
      



    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env,SeedData seedData)

        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(option => {
                option.SwaggerEndpoint("/Swagger/CreaFormOpenAPISpec/Swagger.json", "CreaForm API");
                option.RoutePrefix = "";
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            seedData.SeedUserData();// för seed Admin in data base (bara en gång)
            app.UseCors(X =>
          X.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader()
          );
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
