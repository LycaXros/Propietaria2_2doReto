using Microsoft.AspNetCore.Mvc;
using Propietaria2_2doRetro.Data.EfCore;
using Propietaria2_2doRetro.Models;

namespace Propietaria2_2doRetro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PGController : MDBController<Clasificacion, PGRepository>
    {
        public PGController(PGRepository repo) : base(repo)
        {

        }
    }

}
