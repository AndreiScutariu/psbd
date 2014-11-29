using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.Managers
{
    public interface IUserManager : IManagerBase<User>
    {
        void DeleteById(int userId);
    }

    public class UserManager : ManagerBase<User>, IUserManager
    {
        public void DeleteById(int userId)
        {
            var query = Session.CreateSQLQuery("BEGIN CLINIC.DELETE_USER(:userId); END;");
            query.SetParameter("userId", userId);
            query.ExecuteUpdate();
        }
    }
}