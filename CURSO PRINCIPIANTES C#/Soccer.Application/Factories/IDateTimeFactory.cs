using System;
using System.Collections.Generic;
using System.Text;

namespace Soccer.Application.Factories
{
    public interface IDateTimeFactory
    {
        DateTime CreateUtcNow();
    }
}
