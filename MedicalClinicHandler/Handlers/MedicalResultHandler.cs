using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MedicalClinicHandler.Dto;
using MedicalClinicRepository.Managers;

namespace MedicalClinicHandler.Handlers
{
    public interface IMedicalResultHandler
    {
        string GetMedicalResultForAppointment(int appointmentId);
        string GetMedicalResultDateTimeForAppointment(int appointmentId);
        IEnumerable<DiagnosticDto> GetDiagnosticForAppointment(int appointmentId);
    }

    public class MedicalResultHandler : IMedicalResultHandler
    {
        private readonly IMedicalResultManager _medicalResultManager;
        public MedicalResultHandler()
        {
            _medicalResultManager = new MedicalResultManager();
        }

        public string GetMedicalResultForAppointment(int appointmentId)
        {
            var medicalResult = _medicalResultManager.GetByAppointmentId(appointmentId);
            return medicalResult == null ? "" : medicalResult.Description;
        }

        public string GetMedicalResultDateTimeForAppointment(int appointmentId)
        {
            var medicalResult = _medicalResultManager.GetByAppointmentId(appointmentId);
            return medicalResult == null ? "" : medicalResult.CreatedDate.ToString(CultureInfo.InvariantCulture);
        }

        public IEnumerable<DiagnosticDto> GetDiagnosticForAppointment(int appointmentId)
        {
            var medicalResult = _medicalResultManager.GetByAppointmentId(appointmentId);
            _medicalResultManager.Session.Evict(medicalResult);
            medicalResult = _medicalResultManager.GetByAppointmentId(appointmentId);

            if (medicalResult == null)
                return new List<DiagnosticDto>();

            var medicalResultDiagnostics = medicalResult.Diagnostics;
            _medicalResultManager.Session.Evict(medicalResultDiagnostics);
            medicalResultDiagnostics = medicalResult.Diagnostics;

            return medicalResultDiagnostics.Select(medicalResultDiagnostic => new DiagnosticDto
            {
                Id = medicalResultDiagnostic.Diagnostic.Id,
                Name = medicalResultDiagnostic.Diagnostic.Name,
                Description = medicalResultDiagnostic.Diagnostic.Description
            });
        }
    }
}