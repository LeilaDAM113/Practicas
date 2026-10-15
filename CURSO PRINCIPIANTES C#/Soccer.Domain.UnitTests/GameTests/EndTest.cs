using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Moq;
using Soccer.Domain.Exceptions;
using Soccer.Notification.Abstractions;
using Xunit;

namespace Soccer.Domain.UnitTests.GameTests
{
    public class EndTest
    {
		[Fact]
		public void Given_An_In_Progress_Game_When_Ending_It_Should_Become_Ended()
		{
			// Given
			var id = Guid.Empty;
			var localTeamCode = "RMA";
			var awayTeamCode = "BAR";
			var sut = new Game(id, localTeamCode, awayTeamCode);

			var notifierMock = new Mock<INotifier>();
			var startedOn = new DateTime(year: 2022, month: 3, day: 1, hour: 18, minute: 0, second: 0);
			sut.Start(startedOn, notifierMock.Object);
			var endedOn = startedOn.AddHours(2);

			// When
			sut.End(endedOn, notifierMock.Object);

			// Then
			sut.IsInProgress.Should().BeFalse();
			sut.IsEnded.Should().BeTrue();
			sut.StartedOn.Should().Be(startedOn);
			sut.EndedOn.Should().Be(endedOn);
		}
		[Fact]
		public void Given_An_Ended_Game_When_Ending_It_Should_Throw_GameNotInProgressException() 
		{
			// Given
			var id = Guid.Empty;
			var localTeamCode = "RMA";
			var awayTeamCode = "BAR";
			var sut = new Game(id, localTeamCode, awayTeamCode);
			var startedOn = new DateTime(year: 2022, month: 3, day: 1, hour: 18, minute: 0, second: 0);
			var notifierMock = new Mock<INotifier>();
			sut.Start(startedOn, notifierMock.Object);

			var endedOn = startedOn.AddHours(2);
			sut.End(endedOn, notifierMock.Object);

			var anotherEndedOn = endedOn.AddSeconds(1);

			// When, Then
			Assert.Throws<GameNotInProgressException>(testCode: () =>
			{
				sut.End(anotherEndedOn, notifierMock.Object);
			});

			sut.IsInProgress.Should().BeFalse();
			sut.IsEnded.Should().BeTrue();
			sut.StartedOn.Should().Be(startedOn);
			sut.EndedOn.Should().Be(endedOn);
		}

	}
}
