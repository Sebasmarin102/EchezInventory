using System.ComponentModel.DataAnnotations;

namespace EchezInventory.Data.Entities
{
    public class UserEmailAndPassword
    {
        public int Id { get; set; }

        [Display(Name = "Nombre usuario")]
        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; }

        [Display(Name = "Correo")]
        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Password { get; set; }

        [Display(Name = "Extensión")]
        public int? ExtensionNumber { get; set; }

        [Display(Name = "Contraseña de Extensión")]
        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? ExtensionPassword { get; set; }

        [Display(Name = "País / Continente")]
        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required]
        public string Location { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{Name} {LastName}";
    }
}
