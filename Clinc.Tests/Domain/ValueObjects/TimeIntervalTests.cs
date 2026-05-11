using Clinic.Domain.Exceptions;
using Clinic.Domain.ValueObjects;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clinc.Tests.Domain.ValueObjects
{
    [TestClass]
    public class TimeIntervalTests
    {

        [TestMethod]
        public void Constructor_EndTimeBeforeStartTime_Throws()
        {
            Assert.Throws<BusinessRuleException>(() => new TimeInterval(DateTime.UtcNow, DateTime.UtcNow.AddDays(-1)));
        }

        [TestMethod]
        public void Constructor_ValidTimeInterval_NoExceptions()
        {
            new TimeInterval(DateTime.UtcNow, DateTime.UtcNow.AddDays(1));
            
        }
    }
}
