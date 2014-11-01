using System;
using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.DbMappings
{
    [Serializable]
    public class UserMap : BaseMap<User>
    {
        public UserMap()
        {
            Table("MCUSER");
            Map(x => x.FirstName, "FIRSTNAME");
            Map(x => x.LastName, "LASTNAME");
            Map(x => x.Email, "EMAIL");
            Map(x => x.Password, "PASSWORD");
            References(x => x.UserRole).Class<UserRole>().Columns("ROLE_ID");
        }
    }
}