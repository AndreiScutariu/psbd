namespace MedicalClinicHandler.Dto
{
    public class DiagnosticDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
        public int SpecializationId { get; set; }
    }
}