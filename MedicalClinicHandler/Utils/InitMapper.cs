using AutoMapper;
using MedicalClinicHandler.Dto;
using MedicalClinicRepository.Entities;

namespace MedicalClinicHandler.Utils
{
    public static class InitMapper
    {
        public static void InitUserMapper()
        {
            Mapper.CreateMap<UserDto, User>();
            Mapper.CreateMap<User, UserDto>();

            Mapper.CreateMap<UserRoleDto, UserRole>();
            Mapper.CreateMap<UserRole, UserRoleDto>();
        }
    }
}
