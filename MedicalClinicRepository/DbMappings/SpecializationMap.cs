using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.DbMappings
{
    public class SpecializationMap : BaseMap<Specialization>
    {
        public SpecializationMap()
        {
            Table("SPECIALIZATION");
            Map(x => x.Description, "DESCRIPTION");
            Map(x => x.CreatedDate, "CREATED_DATE");
            HasMany(x => x.StaffSpecializations).KeyColumns.Add("SPECIALIZATION_ID",
                mapping => mapping.Name("SPECIALIZATION_ID"));
        }
    }
}