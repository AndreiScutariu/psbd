using MedicalClinicRepository.Entities;
namespace MedicalClinicRepository.DbMappings
{
    public class MedicalResultDiagnosticMap : BaseMap<MedicalResultDiagnostic>
    {
        public MedicalResultDiagnosticMap()
        {
            Table("MEDICAL_RESULT_DIAGNOSTIC");
            References(x => x.Diagnostic).Class<Diagnostic>().Columns("DIAGNOSTIC_ID");
            References(x => x.MedicalResult).Class<MedicalResult>().Columns("MEDICAL_RESULT_ID");
        }
    }
}