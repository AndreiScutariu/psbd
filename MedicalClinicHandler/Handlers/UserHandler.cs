using System.Collections.Generic;
using System.Linq;
using MedicalClinicHandler.Dto;
using MedicalClinicHandler.DtoEntityMapper;
using MedicalClinicHandler.Utils;
using MedicalClinicRepository.Entities;
using MedicalClinicRepository.Managers;

namespace MedicalClinicHandler.Handlers
{
    public interface IUserHandler
    {
        UserDto SaveUser(UserDto userDto);
        IEnumerable<UserDto> GetAllUsers();
        void DeleteById(int userId);
        UserDto GetById(int userId);
        UserDto GetByEmail(string username);
        UserDto GetByEmailAndPassword(string email, string password);
        void ConfirmSpecializationForUser(int userId, int specializationId);
    }

    public class UserHandler : IUserHandler
    {
        private readonly IUserManager _userManager;

        public UserHandler()
        {
            _userManager = new UserManager();
        }

        public UserDto SaveUser(UserDto userDto)
        {
            using (var tx = _userManager.Session.BeginTransaction())
            {
                var user = _userManager.GetById(userDto.Id) ?? new User();
                UserMapper.SetEntity(user, userDto);
                userDto.Id = _userManager.SaveOrUpdate(user);
                tx.Commit();
            }
            return userDto;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            foreach (var user in _userManager.GetAll())
            {
                _userManager.Session.Evict(user.StaffSpecializations);
                _userManager.Session.Evict(user);
            }
            return _userManager.GetAll().Select(UserMapper.GetDto);
        }

        public void DeleteById(int userId)
        {
            _userManager.DeleteById(userId);
        }

        public UserDto GetById(int userId)
        {
            var obj = _userManager.GetById(userId);
            _userManager.Session.Evict(obj.StaffSpecializations);
            _userManager.Session.Evict(obj);

            return UserMapper.GetDto(_userManager.GetById(userId));
        }

        public UserDto GetByEmail(string username)
        {
            return UserMapper.GetDto(_userManager.GetByEmail(username));
        }

        public UserDto GetByEmailAndPassword(string email, string password)
        {
            return UserMapper.GetDto(_userManager.GetByEmailAndPassword(email, EncryptString.DoHash(password)));
        }

        public void ConfirmSpecializationForUser(int userId, int specializationId)
        {
            _userManager.ConfirmSpecializationForUser(userId, specializationId);
        }
    }
}