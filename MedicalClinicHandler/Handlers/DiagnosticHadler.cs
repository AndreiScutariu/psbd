using System.Collections.Generic;
using System.Linq;
using MedicalClinicHandler.Dto;
using MedicalClinicHandler.DtoEntityMapper;
using MedicalClinicRepository.Managers;

namespace MedicalClinicHandler.Handlers
{
    public interface IDiagnosticHadler
    {
        IEnumerable<DiagnosticDto> GetAllDiagnostics();
    }

    public class DiagnosticHadler : IDiagnosticHadler
    {
        private readonly IDiagnosticManager _diagnosticManager;

        public DiagnosticHadler()
        {
            _diagnosticManager = new DiagnosticManager();
        }

        public IEnumerable<DiagnosticDto> GetAllDiagnostics()
        {
            return _diagnosticManager.GetAll().Select(DiagnosticMapper.GetDto);
        }
    }
}