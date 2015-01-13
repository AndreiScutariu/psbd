using MedicalClinic.Utils.ModelDtoMapper;
using MedicalClinicHandler.Handlers;

namespace MedicalClinic.Models.Medic
{
    public class UserModelBuilder
    {
        protected readonly IUserHandler UserHandler;
        protected readonly IRoleHandler RoleHandler;

        public UserModelBuilder(IUserHandler userHandler, IRoleHandler roleHandler)
        {
            UserHandler = userHandler;
            RoleHandler = roleHandler;
        }

        public UserModel GetUserById(int userId)
        {
            var userDto = UserHandler.GetById(userId);
            return UserMapper.GetModel(userDto);
        }

        public UserModel GetByEmailAndPassword(string email, string password)
        {
            var userDto = UserHandler.GetByEmailAndPassword(email, password);
            return UserMapper.GetModel(userDto);
        }
    }
}