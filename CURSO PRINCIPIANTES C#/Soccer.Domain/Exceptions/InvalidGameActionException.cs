using System;
using System.Collections.Generic;
using System.Text;

namespace Soccer.Domain.Exceptions
{
    public class InvalidGameActionException:Exception
    {
        public InvalidGameActionException(string message) : base(message) { }
    }
}
