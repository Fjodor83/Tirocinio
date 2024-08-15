using GessiWebApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GessiWebApp.Shared.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "L'email è obbligatoria")]
        [EmailAddress(ErrorMessage = "Formato email non valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La password è obbligatoria")]
        [StringLength(100, ErrorMessage = "La password deve essere lunga almeno {2} caratteri.", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Le password non corrispondono")]
        public string ConfirmPassword { get; set; }
        public UserRole Role { get; set; }
    }
           
    
}
