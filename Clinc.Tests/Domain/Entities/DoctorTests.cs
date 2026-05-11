using Clinic.Domain.Entities;
using Clinic.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinc.Tests.Domain.Entities
{
    [TestClass]
    public class DoctorTests
    {
        [TestMethod]
        public void Constructor_WithNull_Name_Throws()
        {
            var email = new Email("felipe@example.com");
            new Doctor(null!, email);
        }

        [TestMethod]
        public void Constructor_NullEmail_Throws()
        {
            new Doctor("kaykay", email: null!);
        }

        [TestMethod]
        public void Constructor_ValidDoctor_NoExceptions()
        {
            var email = new Email("felipe@example.com");

            new Doctor("Felipe", email);

        }
    }
}
