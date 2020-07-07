using Propietaria2_2doRetro.Data;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Propietaria2_2doRetro.Models
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        public bool Activo { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }

        [Required]
        public int LenguajeId { get; set; }
        public virtual Lenguaje Lenguaje { get; set; }

        [Required]
        public int PaisId { get; set; }
        public virtual Pais Pais { get; set; }

        [Required]
        public int StudioId { get; set; }
        public virtual Studio Studio { get; set; }

        [Required]
        public int ClasificacionId { get; set; }
        public virtual Clasificacion Clasificacion { get; set; }

        [Required]
        public string Sipnosis { get; set; }

        [Required]
        public double Budget { get; set; }

        [Required]
        public double BoxOffice { get; set; }

        [Required]
        public int NominacionesOscar { get; set; }
        [Required]
        public int OscarGanados { get; set; }
    }
}
