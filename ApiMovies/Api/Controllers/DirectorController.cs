using ApiMovies.Application.Interfaces;
using ApiMovies.Infraestructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMovies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _directorService;

        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }
        // GET: api/<DirectorController>
        [HttpGet]
        public async  Task<IActionResult> GetAll()
        {
            try
            {
                var directors = await _directorService.GetAllAsync();
                return Ok(directors);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }

            
        }

        // GET api/<DirectorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var directorFind = await _directorService.GetByIdAsync(id);
                return Ok(directorFind);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               return BadRequest(e.Message);
            }
       
        }

        // POST api/<DirectorController>
        [HttpPost]
        public  async Task<IActionResult> Post(Director director)
        {
            try
            {
                 await _directorService.AddAsync(director);
                return Ok("Director Created Succefully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
           
        }

        // PUT api/<DirectorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Director director)
        {
            try
            {
                await _directorService.UpdateAsync(director, id);
                return Ok("Director Updated Succefully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<DirectorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                 await _directorService.DeleteAsync(id);
                return Ok("Director Deleted Succefully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }
    }
}
