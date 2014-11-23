using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.Managers
{
    public interface IMedicalResultDiagnosticManager : IManagerBase<MedicalResultDiagnostic>
    {
    }

    public class MedicalResultDiagnosticManager : ManagerBase<MedicalResultDiagnostic>, IMedicalResultDiagnosticManager
    {
    }
}