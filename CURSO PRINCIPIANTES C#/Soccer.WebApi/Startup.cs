using Soccer.Application;
using Soccer.Application.Factories;
using Soccer.Application.Mappers;
using Soccer.Persistence.Abstractions;
using Soccer.Persistence.InMemory;
using Soccer.Persistence.MongoDb.Extensions;
using Soccer.Persistence.MongoDb.Models;

namespace Soccer.WebApi;

public class Startup
{
	private readonly IConfiguration _configuration;

	public Startup(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddTransient<GameToScoreBoardMapper>();
		services.AddSingleton<IDateTimeFactory, DateTimeFactory>();
		services.AddTransient<GameCommandService>();
		services.AddTransient<GameQueryService>();
		services.AddTransient<Soccer.Notification.Email.Models.SmtpConfiguration>(sp =>
		{
			return new Soccer.Notification.Email.Models.SmtpConfiguration
			{
				Hostname = "localhost",
				Port = 25
			};
		});
		services.AddTransient<Soccer.Notification.Abstractions.INotifier, Soccer.Notification.Email.EmailNotifier>();

		// 1. Comenta la línea de memoria para usar la base de datos:
		// services.AddSingleton<IGameRepository, GameRepositoryInMemory>();
		services.AddMongoDb(sp =>
		{
			var hostname = _configuration.GetValue<string>("DocumentStore:Hostname");
			var username = _configuration.GetValue<string>("DocumentStore:Username");
			var password = _configuration.GetValue<string>("DocumentStore:Password");
			var databaseName = _configuration.GetValue<string>("DocumentStore:DatabaseName");
			var mongoDbOptions = new MongoDbOptions(hostname, username, password, databaseName);
			return mongoDbOptions;
		});
		services.AddControllers();
		services.AddOpenApi();
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		app.UseOpenApi();
		app.UseRouting();
		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllers();
		});
	}
}