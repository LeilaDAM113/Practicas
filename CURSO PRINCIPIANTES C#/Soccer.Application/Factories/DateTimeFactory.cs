using System;
using System.Collections.Generic;
using System.Text;

namespace Soccer.Application.Factories
{
    public class DateTimeFactory : IDateTimeFactory
    {
        public DateTime CreateUtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
