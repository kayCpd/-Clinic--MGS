using Clinic.Domain.Exceptions;
using Clinic.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clinic.Tests.Domain.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        //[ExpectedException(typeof(BusinessRuleException), AllowDerivedTypes = true)]      
        // The above attribute is commented out because MSTest does not support it in .NET 10.0, but the test will still check for the exception manually.
        public void Constructor_NullEmail_Throws()
        {
            // Using null! to bypass the compiler's nullability checks, since we want to test the behavior when null is passed.
            Assert.Throws<BusinessRuleException>(() => new Email(null!));   
        }

        [TestMethod]
        // [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_EmailWithoutAt_Throws()
        {
            Assert.Throws<BusinessRuleException>(() => new Email("felipe.com"));
        }

        [TestMethod]
        public void Constructor_ValidEmail_NoExceptions()
        {
            new Email("felipe@example.com");
            Assert.IsTrue(true); // If we reach this point, it means no exception was thrown, and the test passes.
        }
    }

}
