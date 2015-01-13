using System.Collections.Generic;
using System.Linq;
using MedicalClinic.Models.Medic;
using MedicalClinic.Utils.ModelDtoMapper;
using MedicalClinicHandler.Dto;
using MedicalClinicHandler.Handlers;

namespace MedicalClinic.Models.Admin
{
    public class AdminModelBuilder : UserModelBuilder
    {
        public AdminModelBuilder(IUserHandler userHandler, IRoleHandler roleHandler)
            : base(userHandler, roleHandler)
        {
        }

        public List<UserModel> GetAllUsers()
        {
            var modelList = new List<UserModel>();
            var currentIdx = 0;
            foreach (var model in UserHandler.GetAllUsers().Select(UserMapper.GetModel))
            {
                model.CurrentIndex = ++currentIdx;
                modelList.Add(model);
            }
            return modelList;
        }

        public IEnumerable<UserModel> GetAllUsersWithNotifications()
        {
            var userList = new List<UserModel>();
            foreach (var userModel in GetAllUsers())
            {
                foreach (var spec in userModel.Specialization)
                {
                    if (spec.Confirmed == 0)
                    {
                        if(!userList.Contains(userModel))
                            userList.Add(userModel);
                    }
                }
            }

            return userList;
        }

        public IEnumerable<UserRoleDto> GetAllRoles()
        {
            return RoleHandler.GetAllRoles();
        }

        public void SaveUser(UserModel userModel)
        {
            UserHandler.SaveUser(UserMapper.GetDto(userModel));
        }

        public void DeleteById(int userId)
        {
            UserHandler.DeleteById(userId);
        }

        public void ConfirmSpecializationForUser(int userId, int specializationId)
        {
            UserHandler.ConfirmSpecializationForUser(userId, specializationId);
        }
    }
}