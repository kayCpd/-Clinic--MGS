using Clinic.Domain.Enums;
using Clinic.Domain.Exceptions;
using Clinic.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid DoctorId { get; private set; }
        public Guid GPOfficeId { get; private set; }
        public AppointmentStatus Status { get; private set; }
        public TimeInterval TimeInterval { get; private set; }
        public Patient? Patient { get; private set; }
        public Doctor? Doctor { get; private set; }
        public GPOffice? GPOffice { get; private set; }

        public Appointment(Guid patientId, Guid doctorId, Guid gpOfficeId, TimeInterval timeInterval)
        {
            if (timeInterval._Start < DateTime.UtcNow)
            {
                throw new BusinessRuleException($"The start time cannot be in the past");
            }

            PatientId = patientId;
            DoctorId = doctorId;
            GPOfficeId = gpOfficeId;
            TimeInterval = timeInterval;
            Status = AppointmentStatus.Scheduled;
            Id = Guid.CreateVersion7();

        }

        public void Cancel()
        {
            // An appointment cannot be cancelled if it is not scheduled, and it cannot be cancelled if it is completed
            if (Status != AppointmentStatus.Scheduled
                // Only scheduled appointments can be cancelled, not completed ones
                // An appointment cannot be cancelled if it is not scheduled, and it cannot be cancelled if it is completed
                || Status == AppointmentStatus.Completed)
            {
                throw new BusinessRuleException("Only scheduled appointments can be cancelled");
            }

            Status = AppointmentStatus.Cancelled;
        }

        public void Complete()
        {
            // An appointment cannot be completed if it is not scheduled, and it cannot be completed if it is cancelled
            if (Status != AppointmentStatus.Scheduled
             // Only scheduled appointments can be completed, not cancelled ones
             || Status == AppointmentStatus.Cancelled)
            {
                throw new BusinessRuleException("Only scheduled appointments can be completed");
            }

            Status = AppointmentStatus.Completed;
        }
    }

}
