using Propietaria2_2doRetro.Models;

namespace Propietaria2_2doRetro.Data.EfCore
{
    public class MovieRepository : EfCoreRepository<Movie, MDBContext>
    {
        public MovieRepository(MDBContext context) : base(context)
        {

        }
        // We can add new methods specific to the movie repository here in the future
    }
    public class ActorRepository : EfCoreRepository<Actor, MDBContext>
    {
        public ActorRepository(MDBContext context) : base(context)
        {

        }
    }
}