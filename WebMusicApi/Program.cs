
using Domain.Models;
using System.Reflection;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Domain.Interfaces;
using BusinessLogic.Services;

namespace WebMusicApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register DbContext
            builder.Services.AddDbContext<Domain.Models.WebMusicAppContext>(
                options => options.UseSqlServer(
                    "Server=LAPTOP-886FNGF4\\MSSQLSERVER02;Database=WebMusicApp;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;"));



            // Register repositories
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();





            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

           // Configure the HTTP request pipeline.
             if (app.Environment.IsDevelopment())
             {
                app.UseSwagger();
                app.UseSwaggerUI();

             }

            app.UseHttpsRedirection();
             app.UseAuthorization();
             app.MapControllers();
             app.Run();
        }
    }
}