using Day01.DTOs.StudentDTOs;
using Day01.MappingProfiles;
using Day01.Models;
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

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.MapOpenApi();
				app.UseSwaggerUI(op => op.SwaggerEndpoint("/openapi/v1.json", "v1"));
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
