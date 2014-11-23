using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.DbMappings
{
    public class StaffSpecializationMap : BaseMap<StaffSpecialization>
    {
        public StaffSpecializationMap()
        {
            Table("STAFF_SPECIALIZATION");
            Map(x => x.CreatedDate, "CREATED_DATE");
            References(x => x.Specialization).Class<Specialization>().Columns("SPECIALIZATION_ID");
            References(x => x.User).Class<User>().Columns("MEDIC_ID");
        }
    }
}
