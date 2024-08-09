using ApiMovies.Application.Interfaces;
using ApiMovies.Infraestructure.Data.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateMovieDto movie)
        {
            try
            {
               await _movieService.AddAsync(movie);
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
