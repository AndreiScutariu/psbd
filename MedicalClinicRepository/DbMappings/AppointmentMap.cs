using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.DbMappings
{
    public class AppointmentMap: BaseMap<Appointment>
    {
        public AppointmentMap()
        {
            Table("APPOINTMENT");
            Map(x => x.Description, "DESCRIPTION");
            Map(x => x.AppointmentDate, "APPOINTMENT_DATE");
            References(x => x.User).Class<User>().Columns("USER_ID");
            References(x => x.Pacient).Class<Pacient>().Columns("PACIENT_ID");
        }
    }
}