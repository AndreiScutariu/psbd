using AutoMapper;
using MedicalClinic.Models.User;
using MedicalClinicHandler.Dto;

namespace MedicalClinic.Utils
{
    public static class InitMapper
    {
        public static void InitUserMapper()
        {
            Mapper.CreateMap<UserDto, UserModel>();
            Mapper.CreateMap<UserModel, UserDto>();

            Mapper.CreateMap<UserRoleDto, UserRoleModel>();
            Mapper.CreateMap<UserRoleModel, UserRoleDto>();
        }
    }
}
