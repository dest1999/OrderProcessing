using Microsoft.EntityFrameworkCore;

namespace OrderProcessing
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

            #region DB
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(
                    builder.Configuration.GetConnectionString("SQLite")
                ));
            builder.Services.AddScoped<IRepository<Order>, SQLiteOrderRepository>();
            #endregion

            #region Core logic services
            builder.Services.AddScoped<IInputOrderHandler, InputOrderHandler>();

            builder.Services.AddHostedService<ServicesHostedContainer>();
            builder.Services.AddScoped<IMainProcessingContainer, MainProcessingContainer>();

            builder.Services.AddScoped<IHandler, Talabat>();
            builder.Services.AddScoped<IHandler, Zomato>();
            builder.Services.AddScoped<IHandler, Uber>();

            #endregion

            builder.Services.AddSingleton<IErrorLogger, ErrorLogger>();

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