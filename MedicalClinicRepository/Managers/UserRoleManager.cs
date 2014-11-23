using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.Managers
{
    public interface IUserRoleManager : IManagerBase<UserRole>
    {
    }

    public class UserRoleManager : ManagerBase<UserRole>, IUserRoleManager
    {
    }
}