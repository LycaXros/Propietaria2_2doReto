using Propietaria2_2doRetro.Data;
using System.ComponentModel.DataAnnotations;

namespace Propietaria2_2doRetro.Models
{
    public class User : IEntity
    {
        [Required]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "El nombre no puede ser menor 3 caracteres ni mayor de 100.")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "El nombre de Usuario no puede ser menor 3 caracteres ni mayor de 100.")]
        public string UserName { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public byte[] password_hash { get; set; }
        [Required]
        public byte[] Password_salt { get; set; }

        [Required]
        public string Role { get; set; }
        public int Id { get; set; }
        public bool Activo { get; set; }
    }

    public class CreateUserModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "El nombre no puede ser menor 3 caracteres ni mayor de 100.")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "El nombre de Usuario no puede ser menor 3 caracteres ni mayor de 100.")]
        public string UserName { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string Role { get; set; }
        [Required]
        public string Password { get; set; }
        public int Id { get; set; }
    }


}
