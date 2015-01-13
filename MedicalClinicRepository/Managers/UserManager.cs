using System.Linq;
using MedicalClinicExceptions;
using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.Managers
{
    public interface IUserManager : IManagerBase<User>
    {
        void DeleteById(int userId);
        User GetByEmail(string username);
        User GetByEmailAndPassword(string email, string password);
        void ConfirmSpecializationForUser(int userId, int specializationId);
    }

    public class UserManager : ManagerBase<User>, IUserManager
    {
        public void DeleteById(int userId)
        {
            try
            {
                var query = Session.CreateSQLQuery("BEGIN CLINIC.CLINICPCK.DELETE_USER_SP(:userId); END;");
                query.SetParameter("userId", userId);
                query.ExecuteUpdate();
            }
            catch
            {
                throw new McDatabaseQueryException();
            }
        }
        
        public User GetByEmail(string username)
        {
            return Session.QueryOver<User>().Where(u => u.Email == username).List().FirstOrDefault();
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return Session.QueryOver<User>().Where(u => u.Email == email && u.Password == password).List().FirstOrDefault();
        }

        public void ConfirmSpecializationForUser(int userId, int specializationId)
        {
            try
            {
                var query = Session.CreateSQLQuery("BEGIN CLINIC.CONFIRM_USER_SPECIALIZATION(:userId, :specId); END;");
                query.SetParameter("userId", userId);
                query.SetParameter("specId", specializationId);
                query.ExecuteUpdate();
            }
            catch
            {
                throw new McDatabaseQueryException();
            }
        }
    }
}