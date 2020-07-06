using Propietaria2_2doRetro.Data;
using System.ComponentModel.DataAnnotations;

namespace Propietaria2_2doRetro.Models
{
    public class Clasificacion : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string PGName { get; set; }
        public bool Activo { get; set; }
    }
}
