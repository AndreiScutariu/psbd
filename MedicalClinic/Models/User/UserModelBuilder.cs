using MedicalClinic.Utils.ModelDtoMapper;
using MedicalClinicHandler.Handlers;

namespace MedicalClinic.Models.User
{
    public class UserModelBuilder
    {
        private readonly IUserHandler _userHandler;

        public UserModelBuilder(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        public UserModel SaveUser(UserModel userModel)
        {
            var userDto = _userHandler.SaveUser(UserMapper.GetDto(userModel));
            return UserMapper.GetModel(userDto);
        }
    }
}