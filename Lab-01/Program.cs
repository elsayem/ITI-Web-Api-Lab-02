using Lab_01.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Lab_01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            ////////////
            builder.Services.AddDbContext<StudentContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("con"));
                //if (!options.IsConfigured)
                //{
                //    options.UseSqlServer("conn");
                //}
            });
         
            //to allow all urls to access the API
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            //////////
            //builder.Services.AddDbContext<StudentContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("con"));
            //});


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            //to use HTML
            app.UseStaticFiles();

            // to resolve CORS problem
            app.UseCors("MyPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}
