using Day01.DTOs.StudentDTOs;
using Day01.MappingProfiles;
using Day01.Models;
using Day01.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Day01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. 

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                // Configure Newtonsoft.Json options here
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            }); ;
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<ITIDbContext>(op =>
            {
                op.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("ITI_Conn"));
            });

            builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy => policy
                    .WithOrigins("https://localhost:7289")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            //For Test
            //builder.Services.AddScoped<IEntityRepo<Student>, StudentRepoTest>();
            
            builder.Services.AddScoped<IEntityRepo<Student>, StudentRepo>();
            builder.Services.AddScoped<IEntityRepo<Department>, DepartmentRepo>();

            //builder.Services.AddScoped<EntityRepo<Student>, StudentRepo>();
            //builder.Services.AddScoped<EntityRepo<Department>, DepartmentRepo>();
            builder.Services.AddScoped<IStudentRepoExtra, StudentRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(op => op.SwaggerEndpoint("/openapi/v1.json", "v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowFrontend");

            app.MapControllers();

            app.Run();
        }
    }
}
