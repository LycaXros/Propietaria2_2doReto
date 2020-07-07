using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Propietaria2_2doRetro.Data;
using Propietaria2_2doRetro.Services;

namespace Propietaria2_2doRetro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MDBController<TEntity, TRepository> : ControllerBase
      where TEntity : class, IEntity
      where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public MDBController(TRepository repository)
        {
            this.repository = repository;
        }


        // GET: api/[controller]
        //[AllowAnonymous]
        [Authorize(Policy = Policies.Admin)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.GetAll();
        }
        // GET: api/[controller]/Public
        [AllowAnonymous]
        [HttpGet("Public")]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetPublic()
        {
            var data = await repository.GetAll();
            return data.Where(x => x.Activo == true).ToList();
        }


        // GET: api/[controller]/5
        [Authorize(Policy = Policies.User)]
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var item = await repository.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // PUT: api/[controller]/5
        [Authorize(Policy = Policies.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await repository.Update(entity);
            return NoContent();
        }
        // PUT: api/[controller]/5/Deactivate
        [Authorize(Policy = Policies.Admin)]
        [HttpPut("{id}/Deactivate")]
        public async Task<IActionResult> PutDeactivate(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            entity.Activo = false;
            await repository.Update(entity);
            return NoContent();
        }
        // PUT: api/[controller]/5/Activate
        [Authorize(Policy = Policies.Admin)]
        [HttpPut("{id}/Activate")]
        public async Task<IActionResult> PutActivate(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            entity.Activo = true;
            await repository.Update(entity);
            return NoContent();
        }

        // POST: api/[controller]
        [Authorize(Policy = Policies.Admin)]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            await repository.Add(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // DELETE: api/[controller]/5
        [Authorize(Policy = Policies.Admin)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var item = await repository.Delete(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

    }
}
