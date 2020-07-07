﻿using Microsoft.AspNetCore.Mvc;
using Propietaria2_2doRetro.Data.EfCore;
using Propietaria2_2doRetro.Models;

namespace Propietaria2_2doRetro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : MDBController<Actor, ActorRepository>
    {
        public ActorsController(ActorRepository repo) : base(repo)
        {

        }
    }

}
