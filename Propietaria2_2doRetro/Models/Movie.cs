using Propietaria2_2doRetro.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Propietaria2_2doRetro.Models
{
    public class Movie : IEntity
    {
        public Movie()
        {
            Elenco = new HashSet<Cast>();
        }
        public int Id { get; set; }
        public bool Activo { get; set; }

        
        public string Nombre { get; set; }

        public DateTime? Estreno { get; set; }

        public int? DirectorId { get; set; }
        public virtual Director Director { get; set; }

        public int? LenguajeId { get; set; }
        public virtual Lenguaje Lenguaje { get; set; }


        public int? PaisId { get; set; }
        public virtual Pais Pais { get; set; }


        public int? StudioId { get; set; }
        public virtual Studio Studio { get; set; }


        public int? ClasificacionId { get; set; }
        public virtual Clasificacion Clasificacion { get; set; }

        
        public string Sipnosis { get; set; }


        public double? Budget { get; set; }

        
        public double? BoxOffice { get; set; }

        
        public int? NominacionesOscar { get; set; }
        
        public int? OscarGanados { get; set; }

        
        public int? Runtime { get; set; }

        public virtual ICollection<Cast> Elenco { get; set; }
    }
}
