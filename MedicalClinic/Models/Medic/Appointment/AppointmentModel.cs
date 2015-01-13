using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using MedicalClinic.Models.Medic.Patient;
using MedicalClinic.Utils;

namespace MedicalClinic.Models.Medic.Appointment
{
    public class AppointmentModel : BaseModel
    {
        public int CurrentIndex { get; set; }

        [Required(ErrorMessage = "Descrierea este obligatorie!")]
        [Display(Name = "Descriere")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Data programarii este obligatorie!")]
        [Display(Name = "Data programare")]
        public DateTime AppointmentDate { get; set; }

        public int UserId { get; set; }
        public int PatientId { get; set; }

        public PatientModel PatientModel { get; set; }
        public UserModel UserModel { get; set; }

        public String FormatedDate {
            get { return AppointmentDate.ToString("dddd, MMMM yyyy", new CultureInfo("ro-RO")).UppercaseWords(); }
        }
        public String FormatedTime
        {
            get { return AppointmentDate.ToString("HH:mm"); }
        }

        public String Diagnostic { get; set; }
    }
}