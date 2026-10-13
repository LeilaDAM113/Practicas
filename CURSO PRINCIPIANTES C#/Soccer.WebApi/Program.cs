using Soccer.Application;
using Soccer.Application.Factories;
using Soccer.Application.Mappers;
using Soccer.Notification.Abstractions;
using Soccer.Notification.Email;
using Soccer.Notification.Email.Models;
using Soccer.Persistence.Abstractions;
using Soccer.Persistence.InMemory;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddTransient<GameToScoreBoardMapper>();
services.AddSingleton<IDateTimeFactory, DateTimeFactory>();
services.AddTransient<GameCommandService>();
services.AddTransient<GameQueryService>();
services.AddTransient(sp =>
{
	var smtpConfiguration = new SmtpConfiguration
	{
		Hostname = "localhost",
		Port = 25
	};
	return smtpConfiguration;
});
services.AddSingleton<IGameRepository, GameRepositoryInMemory>();
services.AddTransient<INotifier, EmailNotifier>();
services.AddControllers();
services.AddOpenApi();
var app = builder.Build();
app.UseOpenApi();
app.MapControllers();
app.Run();