using ApiMovies.Application.Interfaces;
using ApiMovies.Infraestructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {


        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        // GET: api/<ActorController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var actors = await _actorService.GetActors();
                return Ok(actors);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        // GET api/<ActorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var actorFind = await _actorService.GetActorId(id);
                return Ok(actorFind);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }

        }

        // POST api/<ActorController>
        [HttpPost]
        public async Task<IActionResult> Post(Actor actor)
        {
            try
            {
                await _actorService.CreateActor(actor);
                return Ok("Actor Created Succefully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        // PUT api/<ActorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Actor actor, int id)
        {
            try
            {
                await _actorService.UpdateActor(actor, id);
                return Ok("Actor Updated Succefully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _actorService.DeleteActor(id);
                return Ok("Actor Deleted Succefully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }
    }
}
