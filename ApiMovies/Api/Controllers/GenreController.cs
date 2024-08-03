using ApiMovies.Application.Interfaces;
using ApiMovies.Core.Domain.Exceptions;
using ApiMovies.Infraestructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMovies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var genres = await _genreService.GetAllGenreAsync();
                return Ok(genres);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequestException(e.Message);
            }
        }

        private IActionResult BadRequestException(string message)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            try
            {
                var genreFind = await _genreService.GetGenreByIdAsync(id);
                return Ok(genreFind);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(Genre genre)
        {
            if (genre == null)
            {
                return BadRequest();
            }

           await _genreService.CreateGenreAsync(genre);

            return Ok("Created genre");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(Genre genre)
        {
            if (genre == null)
            {
                return BadRequest();
            }

            await _genreService.UpdateGenreAsync(genre);

            return Ok("Genre Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
           await _genreService.DeleteGenreAsync(id);
          
            return Ok("Deleted genre");
        }




    }
    }
