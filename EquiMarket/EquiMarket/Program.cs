using Application;
using Domain.Infraestructure.Repositories;
using Infraestructure.EntityFramework.Context;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EquiMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            
            builder.Services.AddControllers();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<ICostumerRepository, CostumerRepository>();
            builder.Services.AddTransient<IProducerRepository, ProducerRepository>();
            builder.Services.AddTransient<IProductRepository, ProductRepository>();
            builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();

            builder.Services.AddDbContext<IEquiMarketContext, EquiMarketContext>(opt => opt.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EquiMarket;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            builder.Services.RegisterApplicationHandlers();


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
