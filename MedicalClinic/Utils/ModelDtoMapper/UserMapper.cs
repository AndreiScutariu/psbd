using AutoMapper;
using MedicalClinic.Models.User;
using MedicalClinicHandler.Dto;

namespace MedicalClinic.Utils.ModelDtoMapper
{
    public static class UserMapper
    {
        static UserMapper()
        {
            InitMapper.InitUserMapper();
        }

        public static UserDto GetDto(UserModel user)
        {
            var userDto = Mapper.Map<UserModel, UserDto>(user);
            userDto.UserRole = new UserRoleDto
                {
                    Id = user.UserRoleId
                };
            return userDto;
        }

        public static UserModel GetModel(UserDto userDto)
        {
            var user = Mapper.Map<UserDto, UserModel>(userDto);
            user.UserRole = userDto.UserRole.RoleName;
            return user;
        }
    }
}