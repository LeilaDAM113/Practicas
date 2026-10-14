using System.Reflection;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ExchangeRateCalculation.FunctionalTests.UseCases
{
    public class CalculateCryptoInEurTests
    {
        private readonly HttpClient _httpClient;

        public CalculateCryptoInEurTests()
        {
			var application = new WebApplicationFactory<Program>()
		.WithWebHostBuilder(builder =>
		{
			builder.ConfigureAppConfiguration((hostingContext, config) =>
			{
				var env = hostingContext.HostingEnvironment;

				config
					.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
					.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: false)
					.AddEnvironmentVariables();

				if (env.IsDevelopment())
				{
					var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
					config.AddUserSecrets(appAssembly, optional: true);
				}
			});
		});
			var client = application.CreateClient();
			_httpClient = client;
		}
		public async Task Given_A_Calculation_Endpoint_And_An_Amount_Of_Crypto_When_Getting_Calculation_Then_It_Should_Return_Expected_Http_Response()
		{
			// Given
			var cryptoCode = "HBAR";
			var cryptoAmount = 300;
			var url = $"/api/cryptoCurrencies/{cryptoCode}/calculations?cryptoAmount={cryptoAmount}";

			// When
			var response = await _httpClient.GetStringAsync(url);

			// Then
			response.Should().Be("63.6 EUR");
		}
	}
}
