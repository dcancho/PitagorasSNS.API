using Microsoft.Azure.Cosmos;
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

			var connectionString = builder.Configuration.GetConnectionString("CosmosDbConnection");
			var cosmosClient = new CosmosClient(connectionString);
			var databaseName = builder.Configuration.GetValue<string>("CosmosDbDatabaseName");

			builder.Services.AddSingleton<CosmosClient>(cosmosClient);
			builder.Services.AddScoped<AppDbContext>(sp => new AppDbContext(cosmosClient, databaseName));

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

			if (app.Environment.IsDevelopment())
			{
				System.Console.WriteLine("Development environment");
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseCors("AllowAllOrigins");
			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}