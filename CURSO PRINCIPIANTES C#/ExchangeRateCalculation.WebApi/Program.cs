using ExchangeRateCalculation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDictionary<string, double>>(sp => new Dictionary<string, double>()
{
	{ "HBAR", 0.212 },
	{ "BTC", 31200.12 },
	{ "ETH", 2172.34 }
});

builder.Services.AddTransient<CryptoCalculator>();
var app = builder.Build();
// la ruta para probar es http://localhost:5131/api/cryptoCurrencies/HBAR/calculations?cryptoAmount=300
app.MapGet(
    "api/cryptoCurrencies/{cryptoCode}/calculations",
    (string cryptoCode, double cryptoAmount, CryptoCalculator cryptoCalculator) =>
    {
        var result = cryptoCalculator.ToEur(cryptoCode, cryptoAmount);
        return Results.Ok($"{result} EUR");
    });


app.Run();
public partial class Program { }
