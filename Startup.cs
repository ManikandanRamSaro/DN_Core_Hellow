using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HellowWorld.Data;
using HellowWorld.Services.CharecterServices;
using HellowWorld.Services.CharecterSkillService;
using HellowWorld.Services.WeaponServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace HellowWorld
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
            services.AddDbContext<DataContext>(x=>x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); //setup connection string
            services.AddControllers();

            services.AddScoped<ICharecterServices,CharecterServices>(); // this will done by manually -> to tell compailer this is services
            services.AddScoped<IAuthRepository,AuthRepository>();
            services.AddScoped<IWeaponServices,WeaponServices>();
            services.AddScoped<ICharecterSkillService,CharecterSkillService>();
            //services.AddTransient -> which make service usable for all controller
            //services.AddSingleton -> which make service to be used only once
            
            services.AddAutoMapper(typeof(Startup)); // configure AutoMapper to the project
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HellowWorld", Version = "v1" });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option=>{
                    option.TokenValidationParameters=new TokenValidationParameters{
                        ValidateIssuerSigningKey=true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                        .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer= false,
                        ValidateAudience= false
                    };
            });
            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();  // getting header context via https and make it accessable inside the controller
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HellowWorld v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();// to configure token based authentication in a application

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
