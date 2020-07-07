using Propietaria2_2doRetro.Models;

namespace Propietaria2_2doRetro.Data.EfCore
{
    public class DirectorRepository : EfCoreRepository<Director, MDBContext>
    {
        public DirectorRepository(MDBContext context) : base(context)
        {

        }
    }
}