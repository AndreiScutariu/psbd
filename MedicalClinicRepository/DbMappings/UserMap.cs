using System;
using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.DbMappings
{
    [Serializable]
    public class UserMap : BaseMap<User>
    {
        public UserMap()
        {
            Table("STAFF");
            Map(x => x.FirstName, "FIRSTNAME");
            Map(x => x.LastName, "LASTNAME");
            Map(x => x.Email, "EMAIL");
            Map(x => x.Password, "PASSWORD");
            References(x => x.UserRole).Class<UserRole>().Columns("ROLE_ID");
            HasMany(x => x.Appointments).KeyColumns.Add("USER_ID", mapping => mapping.Name("USER_ID"));
            HasMany(x => x.StaffSpecializations).KeyColumns.Add("MEDIC_ID", mapping => mapping.Name("MEDIC_ID"));
        }
    }
}