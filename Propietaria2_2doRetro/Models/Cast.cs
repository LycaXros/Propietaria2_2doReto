using Propietaria2_2doRetro.Data;
using System.ComponentModel.DataAnnotations;

namespace Propietaria2_2doRetro.Models
{
    public class Cast : IEntity
    {
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }
        public virtual Movie Pelicula { get; set; }

        [Required]
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }

        public string NombrePersonaje { get; set; }
        public bool Activo { get; set; }
    }
}
