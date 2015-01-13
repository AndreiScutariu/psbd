using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.DbMappings
{
    public class PatientMap : BaseMap<Patient>
    {
        public PatientMap()
        {
            Table("PACIENT");
            Map(x => x.FirstName, "FIRSTNAME");
            Map(x => x.LastName, "LASTNAME");
            Map(x => x.Email, "EMAIL");
            Map(x => x.PhoneNumber, "PHONE");
            Map(x => x.PersonalId, "PERSONAL_ID");
            Map(x => x.BirthDate, "BIRTHDATE");
            //HasMany(x => x.Appointments).KeyColumns.Add("PACIENT_ID", mapping => mapping.Name("PACIENT_ID"));
        }
    }
}