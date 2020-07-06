using Propietaria2_2doRetro.Data;
using System.ComponentModel.DataAnnotations;

namespace Propietaria2_2doRetro.Models
{
    public class Pais : IEntity
    {
        public int Id { get; set; }
        public bool Activo { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
