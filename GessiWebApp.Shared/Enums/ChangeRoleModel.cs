using GessiWebApp.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class ChangeRoleModel
    {
        [Required(ErrorMessage = "Il nuovo ruolo è obbligatorio")]
        public UserRole NewRole { get; set; }
    }
}