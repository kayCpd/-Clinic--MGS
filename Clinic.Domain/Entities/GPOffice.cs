using Clinic.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Domain.Entities
{

    public class GPOffice
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;

        public GPOffice(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(name)} is required");
            }

            Name = name;
            Id = Guid.CreateVersion7();
        }

    }


}
