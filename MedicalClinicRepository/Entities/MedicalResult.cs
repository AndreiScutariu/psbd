using System;
using System.Collections.Generic;

namespace MedicalClinicRepository.Entities
{
    public class MedicalResult : BaseEntity
    {
        public virtual Appointment Appointment { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual string Description { get; set; }

        public virtual IList<MedicalResultDiagnostic> Diagnostics { get; set; }
        public MedicalResult()
        {
            Diagnostics = new List<MedicalResultDiagnostic>();
        }
    }
}
