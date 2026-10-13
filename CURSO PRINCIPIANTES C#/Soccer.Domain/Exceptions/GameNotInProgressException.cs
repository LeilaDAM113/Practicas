using System;
using System.Collections.Generic;
using System.Text;

namespace Soccer.Domain.Exceptions
{
    public class GameNotInProgressException:Exception
    {
        public GameNotInProgressException(Guid id) : base ($"Game {id} has not started"){ }
    }
}
