using System;

namespace MedicalClinicRepository.Entities
{
    public class Specialization : BaseEntity
    {
        public virtual string Description { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}