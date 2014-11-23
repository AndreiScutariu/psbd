using System.Collections.Generic;

namespace MedicalClinicRepository.Entities
{
    public class User : BaseEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual IList<Appointment> Appointments { get; set; }
        public virtual IList<StaffSpecialization> StaffSpecializations { get; set; } 
        public User()
        {
            Appointments = new List<Appointment>();
            StaffSpecializations = new List<StaffSpecialization>();
        }
    }
}