using Microsoft.AspNetCore.Mvc;
using Propietaria2_2doRetro.Data.EfCore;
using Propietaria2_2doRetro.Models;

namespace Propietaria2_2doRetro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : MDBController<Movie, MovieRepository>
    {
        public MoviesController(MovieRepository repo) : base(repo)
        {

        }
    }

}
