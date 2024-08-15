using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "L'email è obbligatoria")]
        [EmailAddress(ErrorMessage = "Formato email non valido")]
        public string Email { get; set; }
    }
}