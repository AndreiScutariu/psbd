using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.DbMappings
{
    public class MedicalResultMap : BaseMap<MedicalResult>
    {
        public MedicalResultMap()
        {
            Table("MEDICAL_RESULT");
            References(x => x.Appointment).Class<Appointment>().Columns("APPOINTMENT_ID");
            Map(x => x.Description, "DESCRIPTION");
            Map(x => x.CreatedDate, "CREATED_DATE");
            HasMany(x => x.Diagnostics).KeyColumns.Add("MEDICAL_RESULT_ID",
                mapping => mapping.Name("MEDICAL_RESULT_ID"));
        }
    }
}