using Propietaria2_2doRetro.Models;

namespace Propietaria2_2doRetro.Data.EfCore
{
    public class GenreRepository : EfCoreRepository<Genero, MDBContext>
    {
        public GenreRepository(MDBContext context) : base(context)
        {

        }
    }
}