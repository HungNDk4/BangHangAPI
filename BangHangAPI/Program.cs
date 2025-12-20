using BangHangAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BangHangAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Add services to the container.
            builder.Services.AddControllers();

            // Cấu hình Swagger cho .NET 8
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Kết nối Database
            var connectString = builder.Configuration.GetConnectionString("MyDb");
            builder.Services.AddDbContext<BanHangContext>(option =>
            {
                option.UseSqlServer(connectString);
            });

            var app = builder.Build();

            // 2. Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Kích hoạt Swagger UI (Màn hình xanh)
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}