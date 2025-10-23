using Microsoft.EntityFrameworkCore;
using RoadAlertApi.Controllers;
using RoadAlertApi.Models;

namespace RoadAlertApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
            });

            builder.Services.AddDbContext<VehicleAlertsContext>(o => o.UseSqlServer("Server=.;Database=VehicleAlerts;Trusted_Connection=True;Encrypt=False;"));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                //c.OperationFilter<DistinguishContentTypesFilter>();
            }); 
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
