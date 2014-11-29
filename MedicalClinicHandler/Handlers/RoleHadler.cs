using System.Linq;
using MedicalClinicHandler.Dto;
using System.Collections.Generic;
using MedicalClinicHandler.DtoEntityMapper;
using MedicalClinicRepository.Managers;

namespace MedicalClinicHandler.Handlers
{
    public interface IRoleHandler
    {
        IEnumerable<UserRoleDto> GetAllRoles();
    }

    public class RoleHadler : IRoleHandler
    {
        private readonly IUserRoleManager _roleManager;

        public RoleHadler()
        {
            _roleManager = new UserRoleManager();
        }

        public IEnumerable<UserRoleDto> GetAllRoles()
        {
            return _roleManager.GetAll().Select(RoleMapper.GetDto);
        }
    }
}