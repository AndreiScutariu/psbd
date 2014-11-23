using System;
using System.Collections.Generic;

namespace MedicalClinicRepository.Entities
{
    public class Pacient : BaseEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string PersonalId { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual IList<Appointment> Appointments { get; set; }

        public Pacient()
        {
            Appointments = new List<Appointment>();
        }
    }
}