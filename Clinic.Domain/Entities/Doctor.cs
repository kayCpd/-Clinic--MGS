using Clinic.Domain.Exceptions;
using Clinic.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Domain.Entities
{
    public class Doctor
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;



        public Doctor(string name, Email email)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(name)} is required");
            }

            if (email is null)
            {
                throw new BusinessRuleException($"The {nameof(email)} is required");
            }

            Name = name;
            Email = email;
            Id = Guid.CreateVersion7();
        }
    }
}
