using System.Collections.Generic;
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
            if (user == null)
                return null;

            var userDto = Mapper.Map<User, UserDto>(user);
            userDto.UserRole = RoleMapper.GetDto(user.UserRole);
            userDto.Specializations = new List<SpecializationDto>();
            foreach (var staffSpecialization in user.StaffSpecializations)
            {
                userDto.Specializations.Add(new SpecializationDto
                    {
                        Id = staffSpecialization.Specialization.Id,
                        CreatedDate = staffSpecialization.CreatedDate,
                        Description = staffSpecialization.Specialization.Description,
                        Confirmed = staffSpecialization.Confirmed
                    });
            }
            userDto.MessageDtos = new List<MessageDto>();
            foreach (var message in user.MessageEntities)
            {
                userDto.MessageDtos.Add(new MessageDto
                    {
                        Id = message.Id,
                        Message = message.Message,
                        CreatedDate = message.CreatedDate,
                        FromUserName = message.From.FirstName + " " + message.From.LastName
                    });
            }
            return userDto;
        }

        public static User SetEntity(User user, UserDto userDto)
        {
            if (userDto == null)
                return null;
   
            Mapper.Map(userDto, user);
            user.Password = EncryptString.DoHash(userDto.Password);
            user.UserRole = ManagerFactory.GetUserRoleManager().GetById(userDto.UserRole.Id);
            return user;
        }
    }
}