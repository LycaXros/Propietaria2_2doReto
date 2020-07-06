using Propietaria2_2doRetro.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Propietaria2_2doRetro.Models
{
    public class Actor : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Cast> Filmes { get; set; }
    }
}
