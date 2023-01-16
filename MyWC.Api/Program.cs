
using Microsoft.EntityFrameworkCore;
using MyWC.DataModels.Models;
using MyWC.Logic.Services;

namespace MyWC.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //������ � �� ������ � ���� ��� ������������ JSON ������, ���� ��� �����
            //��� ���� ������������
            //����� Microsoft.AspNetCore.Mvc.NewtonsoftJson
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );


            string connection = builder.Configuration.GetConnectionString("DBConnection");

            // ��������� �������� MyCompanyDbContext � �������� ������� � ����������
            builder.Services.AddDbContext<MyWcdbContext>(opt =>
                opt.UseSqlServer(connection)
            //.EnableSensitiveDataLogging(true)
            //.LogTo(Console.WriteLine)
            );

            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IPhoneService, PhoneService>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}