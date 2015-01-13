using System;
using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.Managers
{
    public interface ISpecilizationManager : IManagerBase<Specialization>
    {
        bool AddNewSpecializationToUser(int userId, int specId);
    }

    public class SpecilizationManager : ManagerBase<Specialization>, ISpecilizationManager
    {
        public bool AddNewSpecializationToUser(int userId, int specId)
        {
            var userManager = new UserManager();
            var staffSpecializationManager = new StaffSpecializationManager();

            var user = userManager.GetById(userId);
            var newSpecilazation = GetById(specId);

            var staffSpecialization = new StaffSpecialization
                {
                    CreatedDate = DateTime.Now,
                    User = user,
                    Specialization = newSpecilazation,
                    Confirmed = 0
                };
            user.StaffSpecializations.Add(staffSpecialization);

            using (var tx = userManager.Session.BeginTransaction())
            {
                staffSpecializationManager.SaveOrUpdate(staffSpecialization);
                userManager.SaveOrUpdate(user);
                tx.Commit();
            }

            return true;
        }
    }
}