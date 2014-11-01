using System.Collections.Generic;

namespace MedicalClinicRepository.Entities
{
    public class UserRole : BaseEntity
    {
        public virtual string RoleName { get; set; }
        public virtual IList<User> Users { get; set; }
        public UserRole()
        {
            Users = new List<User>();
        }
    }
}