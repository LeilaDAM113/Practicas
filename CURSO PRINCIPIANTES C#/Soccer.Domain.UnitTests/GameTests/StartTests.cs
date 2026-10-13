using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using Soccer.Domain.Exceptions;
using Soccer.Notification.Abstractions;
using FluentAssertions;

namespace Soccer.Domain.UnitTests.GameTests
{
    public class StartTests
    {
		[Fact]
		public void Given_A_Non_Started_Game_When_Starting_It_Should_Become_In_Progress()
		{
			// Given
			var id = Guid.Empty;
			var localTeamCode = "RMA";
			var awayTeamCode = "BAR";
			var sut = new Game(id, localTeamCode, awayTeamCode);

			var startedOn = new DateTime(2022, 3, 1, 18, 0, 0);
			var notifierMock = new Mock<INotifier>();
			var notifier = notifierMock.Object;

			// When
			sut.Start(startedOn, notifier);

			// Then
			sut.IsInProgress.Should().BeTrue();
			sut.IsEnded.Should().BeFalse();
			sut.StartedOn.Should().Be(startedOn);
			notifierMock.Verify(x => x.Notify($"Game {id} started", $"The game between {localTeamCode} and {awayTeamCode} has started on {startedOn}", localTeamCode, awayTeamCode), Times.Once);
		}

	}
}
