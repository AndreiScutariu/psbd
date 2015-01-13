using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.Managers
{
    public interface IPatientManager : IManagerBase<Patient>
    {
    }

    public class PatientManager : ManagerBase<Patient>, IPatientManager
    {
    }
}