using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.Managers
{
    public interface IMedicalResultManager : IManagerBase<MedicalResult>
    {
    }

    public class MedicalResultManager : ManagerBase<MedicalResult>, IMedicalResultManager
    {
    }
}