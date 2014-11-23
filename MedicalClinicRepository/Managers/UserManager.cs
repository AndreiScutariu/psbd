using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.Managers
{
    public interface IUserManager : IManagerBase<User>
    {
    }

    public class UserManager : ManagerBase<User>, IUserManager
    {
    }
}