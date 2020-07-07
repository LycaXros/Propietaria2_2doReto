using Propietaria2_2doRetro.Models;

namespace Propietaria2_2doRetro.Data.EfCore
{
    public class PGRepository : EfCoreRepository<Clasificacion, MDBContext>
    {
        public PGRepository(MDBContext context) : base(context)
        {

        }
    }
}