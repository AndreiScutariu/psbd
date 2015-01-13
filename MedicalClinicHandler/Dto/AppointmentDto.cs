using System;

namespace MedicalClinicHandler.Dto
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime AppointmentDate { get; set; }
        public UserDto UserDto { get; set; }
        public PatientDto PatientDto { get; set; }
    }
}