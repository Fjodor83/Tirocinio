using System.ComponentModel.DataAnnotations;

namespace Shared.Requests
{
    public class NewPasswordRequest
    {
        [Required(ErrorMessage = "Il token è obbligatorio")]
        public string Token { get; set; }

        [Required(ErrorMessage = "L'email è obbligatoria")]
        [EmailAddress(ErrorMessage = "Formato email non valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La nuova password è obbligatoria")]
        [StringLength(100, ErrorMessage = "La password deve essere lunga almeno {2} caratteri.", MinimumLength = 6)]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Le password non corrispondono")]
        public string ConfirmNewPassword { get; set; }
    }
}