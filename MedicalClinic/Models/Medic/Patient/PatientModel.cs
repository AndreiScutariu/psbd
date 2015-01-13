using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalClinic.Models.Medic.Patient
{
    public class PatientModel : BaseModel
    {
        [Required(ErrorMessage = "Prenumele este obligatoriu!")]
        [Display(Name = "Prenume")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu!")]
        [Display(Name = "Nume")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Adresa de email este obligatorie!")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Trebuie sa introduceti o adresa de email valida.")]
        [Display(Name = "Adresa de Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Numarul de telefon este obligatoriu!")]
        [Display(Name = "Numar de telefon")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "CNP-ul este obligatoriu!")]
        [Display(Name = "Cod Numeric Personal")]
        public string PersonalId { get; set; }

        [Required(ErrorMessage = "Data de nastere este obligatorie!")]
        [Display(Name = "Data de nastere")]
        public DateTime BirthDate { get; set; }

        public int CurrentIndex;

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
    }
}