using System.Collections.Generic;
using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.Managers
{
    public interface IAppointmentManager : IManagerBase<Appointment>
    {
        IEnumerable<Appointment> GetAllAppointmentsByUserId(int userId);
    }

    public class AppointmentManager : ManagerBase<Appointment>, IAppointmentManager
    {
        public IEnumerable<Appointment> GetAllAppointmentsByUserId(int userId)
        {
            return Session.QueryOver<Appointment>()
                               .JoinQueryOver(a => a.User)
                               .Where(u => u.Id == userId)
                               .List<Appointment>();
        }
    }
}