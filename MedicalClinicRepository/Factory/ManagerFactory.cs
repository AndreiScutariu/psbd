using MedicalClinicRepository.Entities;
using MedicalClinicRepository.Managers;

namespace MedicalClinicRepository.Factory
{
    public static class ManagerFactory
    {
        public static IUserRoleManager GetUserRoleManager()
        {
            return new UserRoleManager();
        }
    }
}
