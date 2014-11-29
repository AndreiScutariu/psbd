using System.Collections.Generic;
using System.Linq;
using MedicalClinicHandler.Dto;
using MedicalClinicHandler.DtoEntityMapper;
using MedicalClinicRepository.Managers;

namespace MedicalClinicHandler.Handlers
{
    public interface IUserHandler
    {
        UserDto SaveUser(UserDto userDto);
        IEnumerable<UserDto> GetAllUsers();
        void DeleteUser(int userId);
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
                var user = UserMapper.GetEntity(userDto);
                userDto.Id = _userManager.Save(user);
                tx.Commit();
            }
            return userDto;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            return _userManager.GetAll().Select(UserMapper.GetDto);
        }

        public void DeleteUser(int userId)
        {
            _userManager.DeleteById(userId);
        }
    }
}
