using Propietaria2_2doRetro.Models;

namespace Propietaria2_2doRetro.Data.EfCore
{
    public class PaisRepository : EfCoreRepository<Pais, MDBContext>
    {
        public PaisRepository(MDBContext context) : base(context)
        {

        }
    }
}