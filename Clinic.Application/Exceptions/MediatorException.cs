using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Application.Exceptions
{
    public class MediatorException : Exception
    {
        public MediatorException(string message)
            : base(message)
        {

        }
    }
}
