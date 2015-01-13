using System;

namespace MedicalClinicHandler.Dto
{
    public class SpecializationDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Confirmed { get; set; }
    }
}