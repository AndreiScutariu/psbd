using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.DbMappings
{
    public class DiagnosticMap : BaseMap<Diagnostic>
    {
        public DiagnosticMap()
        {
            Table("DIAGNOSTIC");
            Map(x => x.Description, "DESCRIPTION");
            Map(x => x.Solution, "SOLUTION");
            Map(x => x.Name, "NAME");
            Map(x => x.SpecializationId, "SPECIALIZATION_ID");
        }
    }
}