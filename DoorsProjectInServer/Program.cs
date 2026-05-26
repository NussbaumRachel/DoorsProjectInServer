
using Bl;
using Bl.Api;
using Bl.Services;
using Dal;
using Dal.Api;
using Dal.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DoorsProjectInServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // ------------------------
            // Register DAL
            builder.Services.AddScoped<IDal, DalManager>(); // ???? ?????? ?? ???????

            // Register Business Layer
            builder.Services.AddScoped<IBlEmployees, BlEmployeesService>();
            builder.Services.AddSingleton<IBl, BlManager>(); // ?? BlManager ?? ???? ?-IDal, Singleton ?????

            // JWT Service
            builder.Services.AddScoped<JwtService>();

            // Configure JWT Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
                        )
                    };
                });

            // Authorization
            builder.Services.AddAuthorization();

            // Swagger
            builder.Services.AddControllers();
            //Learn more about configuring Swagger / OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddDbContext<DbManager>();
            builder.Services.AddScoped<ExcelService>();
            builder.Services.AddSingleton<IBl, BlManager>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // CORS
            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", policy =>
            {
                policy.WithOrigins("http://localhost:3000")
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            }));


            
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "DoorFiles")),
                RequestPath = "/doorfiles"
            });

           

            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Enable authentication & authorization
            app.UseAuthentication();
            app.UseAuthorization();

            // Enable CORS
            app.UseCors("MyPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}
