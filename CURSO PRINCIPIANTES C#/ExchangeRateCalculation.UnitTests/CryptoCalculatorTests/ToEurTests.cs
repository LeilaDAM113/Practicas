using FluentAssertions;
using Moq;
using Xunit;

namespace ExchangeRateCalculation.UnitTests.CryptoCalculatorTests
{
    public class ToEurTests
    {
		// PARA HACERLO CON FLUENT ASSERTIONS DESCARGAR NUGET FLUENTASSERTIONS

		[Fact]
		public void Given_A_Supported_Crypto_Code_When_Converting_An_Amount_Then_It_Returns_Expected_Result()
		{
			// Given (Dado) SE DESCRIBEN LAS CONDICIONES PREVIAS O EL ESTADO INICIAL ANTES DE REALIZAR LA ACCIÓN
			var ratesInEur = new Dictionary<string, double> { { "HBAR", 0.20 } };
			var sut = new CryptoCalculator(ratesInEur);
			// When(Cuando) DESCRIBE LA ACCIÓN
			var result = sut.ToEur("HBAR", 100);
			// Then(Entonces) DESCRIBE EL RESULTADO ESPERADO
			// CON UNIT
			//Assert.Equal(20,result);
			// CON FLUENT ASSERTIONS
			result.Should().Be(20);
		}
		[Fact]
		public void Given_An_Unsupported_Crypto_Code_When_Converting_An_Amount_Then_It_Throws_CryptoNotSupportedException()
		{
			// Given
			var ratesInEur = new Dictionary<string, double> { { "HBAR", 0.20 } };
			var sut = new CryptoCalculator(ratesInEur);

			// When & Then
			// CON UNIT
			//Assert.Throws<CryptoNotSupportedException>(testCode: () =>
			//{
			//	_ = sut.ToEur(cryptoCode: "BTC", cryptoAmount: 100);
			//});
			// CON FLUENT ASSERTIONS
			sut.Invoking(x => x.ToEur(cryptoCode: "BTC", cryptoAmount: 100))
           .Should()
		   .Throw<CryptoNotSupportedException>()
           .WithMessage($"Unsupported crypto BTC");

		}
		[Fact]
		public void Given_A_Supported_Crypto_Code_In_Lower_Case_When_Converting_An_Amount_Then_It_Throws_CryptoNotSupportedException()
		{
			// Given
			var ratesInEur = new Dictionary<string, double> { { "HBAR", 0.20 } };
			var sut = new CryptoCalculator(ratesInEur);

			// When & Then
			// CON UNIT
			//Assert.Throws<CryptoNotSupportedException>(testCode: () =>
			//{
			//	_ = sut.ToEur("hbar" , 100);
			//});
			// CON FLUENT ASSERTIONS
			sut.Invoking(x => x.ToEur(cryptoCode: "hbar", cryptoAmount: 100))
		   .Should()
		   .Throw<CryptoNotSupportedException>()
		   .WithMessage($"Unsupported crypto hbar");
		}

		[Theory]
		[InlineData("BTC", 30000, 2, 60000)]
		[InlineData("HBAR", 0.20, 100, 20)]
		[InlineData("ETH", 2300, 10, 23000)]
		public void Given_A_Crypto_Code_And_Exchange_Rate_When_Converting_An_Amount_Then_It_Returns_Expected_Result(string cryptoCode, double rateInEur, double amount, double expectedResult)
		{
			// Given
			var ratesInEur = new Dictionary<string, double> { { cryptoCode, rateInEur } };
			var sut = new CryptoCalculator(ratesInEur);

			// When 
			var result = sut.ToEur(cryptoCode, amount);

			// Then
			// CON UNIT
			//Assert.Equal(expectedResult, result);
			// CON FLUENT ASSERTIONS
			result.Should().Be(expectedResult);
		}

		[Fact]
		public void Given_Any_Supported_Crypto_Code_When_Converting_An_Amount_Then_It_Returns_Expected_Result()
		{
			// Given
			var ratesInEurMock = new Mock<IDictionary<string, double>>();
			double rate = 0.50;

			ratesInEurMock
				.Setup(x => x.TryGetValue(It.IsAny<string>(), out rate))
				.Returns(true);

			var sut = new CryptoCalculator(ratesInEurMock.Object);

			// When
			var result = sut.ToEur(cryptoCode: "FOO", cryptoAmount: 100);

			// Then
			result.Should().Be(50);
			ratesInEurMock.Verify(x => x.TryGetValue("FOO", out rate), Times.Once());
		}

		[Fact]
		public void Given_Any_Unsupported_Crypto_Code_When_Converting_An_Amount_Then_It_Throws_CryptoNotSupportedException()
		{
			// Given
			var ratesInEurMock = new Mock<IDictionary<string, double>>();
			double rate = 0.50;

			ratesInEurMock
				.Setup(x => x.TryGetValue(It.IsAny<string>(), out rate))
				.Returns(false);

			var sut = new CryptoCalculator(ratesInEurMock.Object);

			// When & Then
			sut.Invoking(x => x.ToEur(cryptoCode: "FOO", cryptoAmount: 100))
			   .Should()
			   .Throw<CryptoNotSupportedException>()
			   .WithMessage("Unsupported crypto FOO");
		}
	}
}
