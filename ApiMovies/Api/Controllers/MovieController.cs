using ApiMovies.Infraestructure.Data.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {


        [HttpPost]
        public async Task<IActionResult> Post(CreateMovieDto movie)
        {
            try
            {
               
                return Ok("Movie Created Succefully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

    }
}
