using System;
using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.DbMappings
{
    [Serializable]
    public class UserRoleMap : BaseMap<UserRole>
    {
        public UserRoleMap()
        {
            Table("USERROLE");
            Map(x => x.RoleName, "ROLENAME");
            HasMany(x => x.Users).KeyColumns.Add("ROLE_ID", mapping => mapping.Name("ROLE_ID"));
        }
    }
}