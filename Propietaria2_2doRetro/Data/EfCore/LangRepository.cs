using Propietaria2_2doRetro.Models;

namespace Propietaria2_2doRetro.Data.EfCore
{
    public class LangRepository : EfCoreRepository<Lenguaje, MDBContext>
    {
        public LangRepository(MDBContext context) : base(context)
        {

        }
    }
}