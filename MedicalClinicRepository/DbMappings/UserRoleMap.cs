using System;
using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.DbMappings
{
    [Serializable]
    public class UserRoleMap : BaseMap<UserRole>
    {
        public UserRoleMap()
        {
            Table("USER_ROLE");
            Map(x => x.RoleName, "ROLE_NAME");
        }
    }
}