using System;
using System.Collections.Generic;
using System.Text;

namespace Soccer.Domain.Exceptions
{
    public class GameInProgressException : Exception
    {
        public GameInProgressException(Guid id) : base($"Game {id} already in progress")
        {
        }
    }
}
