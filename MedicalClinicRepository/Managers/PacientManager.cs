using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.Managers
{
    public interface IPacientManager : IManagerBase<Pacient>
    {
    }

    public class PacientManager : ManagerBase<Pacient>, IPacientManager
    {
    }
}