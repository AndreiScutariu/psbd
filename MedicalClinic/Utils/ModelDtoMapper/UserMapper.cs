using System.Collections.Generic;
using AutoMapper;
using MedicalClinic.Models.Medic;
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
            if (user == null)
                return null;

            var userDto = Mapper.Map<UserModel, UserDto>(user);
            userDto.UserRole = new UserRoleDto
                {
                    Id = user.UserRoleId
                };
            return userDto;
        }

        public static UserModel GetModel(UserDto userDto)
        {
            if (userDto == null)
                return null;
            
            var user = Mapper.Map<UserDto, UserModel>(userDto);
            user.UserRole = userDto.UserRole.RoleName;
            user.Specialization = new List<SpecializationDto>(userDto.Specializations);
            user.Notification = userDto.Notification;
            return user;
        }
    }
}