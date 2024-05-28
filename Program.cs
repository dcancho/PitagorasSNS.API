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

            var environment = builder.Environment.EnvironmentName;

            string connectionString;
            try
            {
                if (environment == "Production")
                {
                    connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
                }
                else
                {
                    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting connection string", ex);
            }
            var client = new MongoClient(connectionString);
            var databaseName = new MongoUrl(connectionString).DatabaseName;

            builder.Services.AddSingleton<IMongoClient>(client);
            builder.Services.AddScoped<AppDbContext>(sp => new AppDbContext(client, databaseName));

            builder.Services.AddScoped<IClassRepository, ClassRepository>();
            builder.Services.AddScoped<IClassService, ClassService>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<IScoresRecordRepository, ScoresRecordRepository>();
            builder.Services.AddScoped<IScoresRecordService, ScoresRecordService>();
            builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
            builder.Services.AddScoped<ITeacherService, TeacherService>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICourseService, CourseService>();

            builder.Services.AddAutoMapper(typeof(ResourceToModelProfile), typeof(ModelToResourceProfile));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });


            var app = builder.Build();
			
			app.UseSwagger();
			app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseCors("AllowAllOrigins");
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}