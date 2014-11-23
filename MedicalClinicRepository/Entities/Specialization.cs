using System;
using System.Collections.Generic;

namespace MedicalClinicRepository.Entities
{
    public class Specialization : BaseEntity
    {
        public virtual string Description { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual IList<StaffSpecialization> StaffSpecializations { get; set; }

        public Specialization()
        {
            StaffSpecializations = new List<StaffSpecialization>();
        }
    }
}