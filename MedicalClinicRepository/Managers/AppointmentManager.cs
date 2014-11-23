using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.Managers
{
    public interface IAppointmentManager : IManagerBase<Appointment>
    {
    }

    public class AppointmentManager : ManagerBase<Appointment>, IAppointmentManager
    {
    }
}