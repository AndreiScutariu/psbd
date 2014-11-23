using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.Managers
{
    public interface IDiagnosticManager : IManagerBase<Diagnostic>
    {
    }
    public class DiagnosticManager : ManagerBase<Diagnostic>, IDiagnosticManager
    {
    }
}