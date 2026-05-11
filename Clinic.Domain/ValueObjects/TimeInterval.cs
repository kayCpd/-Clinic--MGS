using Clinic.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Domain.ValueObjects
{
    public class TimeInterval
    {
        public DateTime _Start { get; init; }
        public DateTime _End { get; init; }

        public TimeInterval(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new BusinessRuleException("The start time cannot be in the past (after the end time)");
            }

            _Start = start;
            _End = end;
        }
    }
}
