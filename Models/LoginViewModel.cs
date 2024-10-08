using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [EmailAddress(ErrorMessage = "Debe ser un email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}


