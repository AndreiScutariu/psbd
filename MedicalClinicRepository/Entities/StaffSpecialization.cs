using System;

namespace MedicalClinicRepository.Entities
{
    public class StaffSpecialization : BaseEntity
    {
        public virtual User User { get; set; } 
        public virtual Specialization Specialization { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}
