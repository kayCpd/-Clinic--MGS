using Clinic.Domain.Entities;
using Clinic.Domain.Exceptions;
using Clinic.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinc.Tests.Domain.Entities
{
    [TestClass]
    public class PatientTests
    {
        [TestMethod]
        public void Constructor_NullName_Throws()
        {
            var email = new Email("felipe@example.com");
            new Patient(null!, email);
        }

        [TestMethod]        
        public void Constructor_NullEmail_Throws()
        {
            new Patient("Felipe", email: null!);
        }

        [TestMethod]
        public void Constructor_ValidPatient_NoExceptions()
        {
            var email = new Email("felipe@example.com");
            new Patient("Felipe", email);
        }
    }
}
