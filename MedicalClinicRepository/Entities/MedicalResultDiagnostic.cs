using System;
namespace MedicalClinicRepository.Entities
{
    public class MedicalResultDiagnostic : BaseEntity
    {
        public virtual Diagnostic Diagnostic { get; set; }
        public virtual MedicalResult MedicalResult { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}