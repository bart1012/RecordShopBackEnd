using Microsoft.EntityFrameworkCore;
using RecordShop.Repositories;
using RecordShop.Services;
using RecordShop.Utils;

namespace RecordShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson(); ;
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<RecordShopDbContext>(options =>
            {
                if (builder.Environment.IsDevelopment())
                {

                    options.UseInMemoryDatabase("InMemoryDB");
                }
                else if (builder.Environment.IsProduction())
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
                }
            });
            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
            builder.Services.AddScoped<IAlbumService, AlbumService>();

            var app = builder.Build();

            Seeder.AddAlbumData(app);

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
