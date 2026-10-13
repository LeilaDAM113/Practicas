using System;
using System.Collections.Generic;
using System.Text;
using Soccer.Application.Mappers;
using Soccer.Application.Models;
using Soccer.Persistence.Abstractions;

namespace Soccer.Application
{
    public class GameQueryService
    {
		private readonly IGameRepository _gameRepository;
		private readonly GameToScoreBoardMapper _gameToScoreBoardMapper;

		public GameQueryService(
			IGameRepository gameRepository,
			GameToScoreBoardMapper gameToScoreBoardMapper)
		{
			_gameRepository = gameRepository;
			_gameToScoreBoardMapper = gameToScoreBoardMapper;
		}

		public ScoreBoard GetScoreBoard(Guid id)
		{
			var game = _gameRepository.GetGame(id);
			var scoreBoard = _gameToScoreBoardMapper.Map(game);
			return scoreBoard;
		}
	}
}
