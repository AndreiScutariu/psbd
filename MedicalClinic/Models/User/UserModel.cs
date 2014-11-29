using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MedicalClinic.Models.User
{
    public class UserModel : BaseModel
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

        [Required(ErrorMessage = "Parola este obligatorie!")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [System.Web.Mvc.Compare("Password", ErrorMessage = "Parola trebuie confirmata")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirma parola")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Rol")]
        public int UserRoleId { get; set; }

        public string UserRole { get; set; }
        public int CurrentIndex { get; set; }
        public string FullName 
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
        public string Parrent
        {
            get { return @"-"; }
        }
    }
}