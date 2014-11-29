using System.Collections.Generic;
using AutoMapper;
using MedicalClinicHandler.Dto;
using MedicalClinicHandler.Utils;
using MedicalClinicRepository.Entities;

namespace MedicalClinicHandler.DtoEntityMapper
{
    public static class RoleMapper
    {
        static readonly Dictionary<string, string> Roles = new Dictionary<string, string>
            {
                {"Admin", "Administrator"},
                {"Doctor", "Medic"},
                {"Nurse", "Asistent"},
            };

        static RoleMapper()
        {
            InitMapper.InitUserMapper();
        }

        public static UserRoleDto GetDto(UserRole role)
        {
            var userDto = Mapper.Map<UserRole, UserRoleDto>(role);
            userDto.RoleName = Roles[role.RoleName];
            return userDto;
        }

        public static UserRole GetEntity(UserRoleDto roleDto)
        {
            return Mapper.Map<UserRoleDto, UserRole>(roleDto);
        }
    }
}
