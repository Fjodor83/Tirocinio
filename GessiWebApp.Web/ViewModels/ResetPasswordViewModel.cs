using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string Token { get; set; }

        [Required(ErrorMessage = "L'email è obbligatoria")]
        [EmailAddress(ErrorMessage = "Formato email non valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La nuova password è obbligatoria")]
        [StringLength(100, ErrorMessage = "La password deve essere lunga almeno {2} caratteri.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nuova password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Conferma nuova password")]
        [Compare("NewPassword", ErrorMessage = "Le password non corrispondono")]
        public string ConfirmNewPassword { get; set; }
    }
}