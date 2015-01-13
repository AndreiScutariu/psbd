using System.Collections.Generic;
using MedicalClinicHandler.Dto;

namespace MedicalClinic.Models.Medic.Appointment
{
    public class AppointmentDiagnosticModel : BaseModel
    {
        public AppointmentModel AppointmentModel { get; set; }
        public List<int> GetSpecIds { get; set; }

        public List<DiagnosticDto> DiagnosticDtos { get; set; }
        public string CreatedDate { get; set; }

        public List<MessageDto> MessageDtos { get; set; }

        public string LastDescription;
    }
}