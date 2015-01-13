namespace MedicalClinicRepository.Entities
{
    public class Diagnostic : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Solution { get; set; }
        public virtual int SpecializationId { get; set; }
    }
}