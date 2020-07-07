using Propietaria2_2doRetro.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Propietaria2_2doRetro.Models
{
    public class Pais : IEntity
    {
        public Pais()
        {
            Films = new HashSet<Movie>();
        }
        public int Id { get; set; }
        public bool Activo { get; set; }

        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<Movie> Films { get; set; }
    }
}
