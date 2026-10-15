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
	public class ScoreGoalTest
	{
		[Fact]
		public void Given_A_Game_In_Progress_When_Local_Team_Scores_Then_Local_Team_Goal_Is_Added() 
		{
			// Given
			var id = Guid.Empty;
			var localTeamCode = "RMA";
			var awayTeamCode = "BAR";
			var sut = new Game(id, localTeamCode, awayTeamCode);
			var notifierMock = new Mock<INotifier>();
			var startedOn = new DateTime(year: 2022, month: 3, day: 1, hour: 18, minute: 0, second: 0);
			sut.Start(startedOn, notifierMock.Object);
			var scoredOn = startedOn.AddMinutes(20);
			var scoredBy = "Esther";
			var goal = new Goal(scoredOn, scoredBy);

			// When
			sut.ScoreGoal(goal, isLocalTeam: true);

			// Then
			sut.LocalTeamGoals.Count.Should().Be(1);
			sut.AwayTeamGoals.Count.Should().Be(0);
			sut.LocalTeamGoals.Single().Should().Be(goal);
		}

		[Fact]
		public void Given_A_Game_In_Progress_When_Away_Team_Scores_Then_Away_Team_Goal_Is_Added() 
		{
			// Given
			var id = Guid.Empty;
			var localTeamCode = "RMA";
			var awayTeamCode = "BAR";
			var sut = new Game(id, localTeamCode, awayTeamCode);
			var notifierMock = new Mock<INotifier>();
			var startedOn = new DateTime(year: 2022, month: 3, day: 1, hour: 18, minute: 0, second: 0);
			sut.Start(startedOn, notifierMock.Object);
			var scoredOn = startedOn.AddMinutes(20);
			var scoredBy = "Rolfö";
			var goal = new Goal(scoredOn, scoredBy);

			// When
			sut.ScoreGoal(goal, isLocalTeam: false);
		}

		[Fact]
		public void Given_A_Game_Not_Started_When_Local_Team_Scores_Then_It_Should_Throw_GameNotInProgressException()
		{
			// Given
			var id = Guid.Empty;
			var localTeamCode = "RMA";
			var awayTeamCode = "BAR";
			var sut = new Game(id, localTeamCode, awayTeamCode);

			var scoredOn = new DateTime(year: 2022, month: 3, day: 1, hour: 18, minute: 0, second: 0);
			var scoredBy = "Esther";
			var goal = new Goal(scoredOn, scoredBy);

			// When

			// When, Then
			Assert.Throws<GameNotInProgressException>(() =>
			{
				sut.ScoreGoal(goal, isLocalTeam: true);
			});

			// Then
			sut.LocalTeamGoals.Count.Should().Be(0);
			sut.AwayTeamGoals.Count.Should().Be(0);
		}

		[Fact]
		public void Given_A_Game_Ended_When_Local_Team_Scores_Then_It_Should_Throw_GameNotInProgressException()
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
			sut.End(endedOn, notifierMock.Object);

			var scoredOn = endedOn.AddSeconds(1);
			var scoredBy = "Esther";
			var goal = new Goal(scoredOn, scoredBy);

			// When, Then
			Assert.Throws<GameNotInProgressException>(() =>
			{
				sut.ScoreGoal(goal, isLocalTeam: true);
			});
			// Then
			sut.LocalTeamGoals.Count.Should().Be(0);
			sut.AwayTeamGoals.Count.Should().Be(0);
		}
	}
}
