using AutoMapper;
using MedicalClinicHandler.Dto;
using MedicalClinicHandler.Utils;
using MedicalClinicRepository.Entities;
using MedicalClinicRepository.Factory;

namespace MedicalClinicHandler.DtoEntityMapper
{
    public static class UserMapper
    {
        static UserMapper()
        {
            InitMapper.InitUserMapper();
        }

        public static UserDto GetDto(User user)
        {
            return Mapper.Map<User, UserDto>(user);
        }

        public static User GetEntity(UserDto userDto)
        {
            var user = Mapper.Map<UserDto, User>(userDto);
            user.Password = Encrypt.DoHash(userDto.Password);
            user.UserRole = ManagerFactory.GetUserRoleManager().GetById(userDto.UserRole.Id);
            return user;
        }
    }
}