using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        [Display(Name = "Cognome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "L'email è obbligatoria")]
        [EmailAddress(ErrorMessage = "Formato email non valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La password è obbligatoria")]
        [StringLength(100, ErrorMessage = "La password deve essere lunga almeno {2} caratteri.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Conferma password")]
        [Compare("Password", ErrorMessage = "Le password non corrispondono")]
        public string ConfirmPassword { get; set; }
    }
}