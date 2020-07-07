﻿using Propietaria2_2doRetro.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Propietaria2_2doRetro.Models
{
    public class Studio : IEntity
    {
        public Studio()
        {
            Films = new HashSet<Movie>();
        }
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public virtual ICollection<Movie> Films { get; set; }

    }
}