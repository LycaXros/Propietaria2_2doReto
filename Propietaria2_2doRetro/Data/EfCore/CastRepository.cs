using Propietaria2_2doRetro.Models;

namespace Propietaria2_2doRetro.Data.EfCore
{
    public class CastRepository : EfCoreRepository<Cast, MDBContext>
    {
        public CastRepository(MDBContext context) : base(context)
        {

        }
    }
}