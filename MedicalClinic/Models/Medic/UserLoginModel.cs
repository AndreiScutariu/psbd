using System.ComponentModel.DataAnnotations;

namespace MedicalClinic.Models.Medic
{
    public class UserLoginModel
    {
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

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}