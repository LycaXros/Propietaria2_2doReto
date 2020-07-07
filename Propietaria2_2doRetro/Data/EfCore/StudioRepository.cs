using Propietaria2_2doRetro.Models;

namespace Propietaria2_2doRetro.Data.EfCore
{
    public class StudioRepository : EfCoreRepository<Studio, MDBContext>
    {
        public StudioRepository(MDBContext context) : base(context)
        {

        }
    }
}