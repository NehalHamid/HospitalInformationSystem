
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using HospitalInformationSystem.API.Config;
using HospitalInformationSystem.API.Helpers;
using HospitalInformationSystem.Data;

using HospitalInformationSystem.Models.Models;
using HospitalInformationSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Diagnostics;
using System.Text;

namespace HospitalInformationSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
        
           ;


          
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("Connect"))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).
            LogTo(log => Debug.WriteLine(log), LogLevel.Information)
            .EnableSensitiveDataLogging());


            // Add services to the container.
            builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            _ = builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(o =>
              {
                  o.RequireHttpsMetadata = false;
                  o.SaveToken = false;
                  o.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidIssuer = builder.Configuration["JWT:Issuer"],
                      ValidAudience = builder.Configuration["JWT:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                  };
              });

            // Configure authorization
            _ = builder.Services.AddAuthorization(options =>
            {
                // Add policy that requires the user to be in the "Admin" role
                options.AddPolicy("ITPolicy", policy => policy.RequireRole("IT"));
                options.AddPolicy("DoctorPolicy", policy => policy.RequireRole("Doctor"));
                options.AddPolicy("PatientPolicy", policy => policy.RequireRole("Patient"));
                options.AddPolicy("NursePolicy", policy => policy.RequireRole("Nurse"));
                options.AddPolicy("ReceptionPolicy", policy => policy.RequireRole("Reception"));
                options.AddPolicy("X-rayPolicy", policy => policy.RequireRole("X-ray"));
                options.AddPolicy("TestsPolicy", policy => policy.RequireRole("Tests"));
                options.AddPolicy("PharmacyPolicy", policy => policy.RequireRole("Pharmacy"));


            });



            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(opt =>
              opt.RegisterModule(new AutofacModule()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(builder.Environment.ContentRootPath, "/Users/c.delivery for lap/source/repos/HospitalInformationSystem/HospitalInformationSystem.API/Upload/Files")),
                RequestPath = "/Resources"
            });

            app.UseRouting();

            app.UseCors("AllowReactApp");



            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            _ = app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
