using Clinic.Domain.Entities;
using Clinic.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinc.Tests.Domain.Entities
{
    [TestClass]
    public class GPOfficeTests
    {
        [TestMethod]
        public void Constructor_WithNull_Nmae_Throws()
        {        
            new GPOffice(null!);  
        }

   }
}
