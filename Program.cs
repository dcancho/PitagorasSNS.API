using MongoDB.Driver;
using PitagorasSNS.API.Mapping;
using PitagorasSNS.API.Shared.Infrastructure.Configuration;
using PitagorasSNS.API.Shared.Infrastructure.Repositories;
using PitagorasSNS.API.SocialNetworkService.Application.Internal.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Repositories;
using PitagorasSNS.API.SocialNetworkService.Domain.Services;

namespace PitagorasSNS.API
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

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            const string databaseName = "dev_pitagorassns";
            builder.Services.AddSingleton<IMongoClient>(new MongoClient(connectionString));

            builder.Services.AddScoped<AppDbContext>(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return new AppDbContext(client, databaseName);
            });

            builder.Services.AddScoped<IClassRepository, ClassRepository>();
            builder.Services.AddScoped<IClassService, ClassService>();
            builder.Services.AddAutoMapper(typeof(ResourceToModelProfile), typeof(ModelToResourceProfile));
            
            

            var app = builder.Build();

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