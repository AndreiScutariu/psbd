namespace MedicalClinicRepository.Entities
{
    public class User : BaseEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}