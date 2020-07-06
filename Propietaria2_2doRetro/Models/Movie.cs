using Propietaria2_2doRetro.Data;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Propietaria2_2doRetro.Models
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        public bool Activo { get; set; }

    }
}
