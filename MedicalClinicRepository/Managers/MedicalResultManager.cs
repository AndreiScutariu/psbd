using System.Linq;
using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.Managers
{
    public interface IMedicalResultManager : IManagerBase<MedicalResult>
    {
        MedicalResult GetByAppointmentId(int id);
    }

    public class MedicalResultManager : ManagerBase<MedicalResult>, IMedicalResultManager
    {
        public MedicalResult GetByAppointmentId(int id)
        {
            return GetAll().FirstOrDefault(medResult => medResult.Appointment != null && medResult.Appointment.Id == id);
        }
    }
}