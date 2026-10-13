using System;
using System.Collections.Generic;
using System.Text;

namespace Soccer.Domain.Exceptions
{
	public class GameEndedException : Exception
	{
		public GameEndedException(Guid id) : base($"Game {id} already ended")
		{
		}
	}
}
