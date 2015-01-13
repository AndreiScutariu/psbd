using System;

namespace MedicalClinicRepository.Entities
{
    public class Appointment : BaseEntity
    {
        public virtual string Description { get; set; }
        public virtual DateTime AppointmentDate { get; set; }
        public virtual User User { get; set; }
        public virtual Patient Patient { get; set; }
    }
}