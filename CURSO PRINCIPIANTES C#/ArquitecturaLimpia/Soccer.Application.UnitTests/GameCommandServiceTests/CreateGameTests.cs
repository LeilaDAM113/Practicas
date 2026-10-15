using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Moq;
using Soccer.Application.Factories;
using Soccer.Application.Models;
using Soccer.Notification.Abstractions;
using Soccer.Persistence.Abstractions;
using Soccer.Persistence.InMemory;

namespace Soccer.Application.UnitTests.GameCommandServiceTests
{
    public class CreateGameTests
    {
		[Fact]
		public void Given_A_New_Game_When_Creating_It_Then_It_Should_Return_A_Valid_Id()
		{
			// Given
			var newGame = new NewGame
			{
				LocalTeamCode = "RMA",
				ForeignTeamCode = "BAR"
			};

			var gameRepositoryMock = new Mock<IGameRepository>();
			var gameRepository = gameRepositoryMock.Object;
			var notifierMock = new Mock<INotifier>();
			var sut = new GameCommandService(gameRepository, new DateTimeFactory(), notifierMock.Object);

			// When
			var result = sut.CreateGame(newGame);

			// Then
			result.Should().NotBeEmpty();
		}

		[Fact]
		public void Given_A_New_Game_When_Creating_It_Then_It_Should_Return_A_Valid_Id_With_Mock()
		{
			// Given
			var newGame = new NewGame
			{
				LocalTeamCode = "RMA",
				ForeignTeamCode = "BAR"
			};

			var gameRepositoryMock = new Mock<IGameRepository>();
			var gameRepository = gameRepositoryMock.Object;
			var notifier = Mock.Of<INotifier>();
			var sut = new GameCommandService(
				gameRepository,
				Mock.Of<IDateTimeFactory>(),
				notifier
			);

			// When
			var result = sut.CreateGame(newGame);

			// Then
			result.Should().NotBeEmpty();
		}
	}
}
