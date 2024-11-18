using BookLib.DTOs;
using BookLib.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenresRepo _repo;

        public GenresController(IGenresRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var genres = _repo.GetAll();
            if (genres == null || !genres.Any())
            {
                return NotFound();
            }
            return Ok(genres);
        }

        [HttpGet("{id}")] // Corrected route to use id as a parameter
        public IActionResult GetById(int id)
        {
            var genre = _repo.GetById(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpPost]
        public IActionResult AddGenre(GenreDto genreDto) // Renamed method to be more descriptive
        {
            if (genreDto == null)
            {
                return BadRequest("Genre data is required.");
            }
            _repo.AddBook(genreDto);
            return Ok(); // Assuming GenreDto has an Id property
        }

        [HttpPut("{id}")] // Added id parameter to the route
        public IActionResult UpdateGenre(int id, GenreDto genreDto)
        {
            if (genreDto == null)
            {
                return BadRequest("Genre data is required.");
            }
            _repo.Update(genreDto, id);
            return NoContent(); // 204 No Content for successful update
        }

        [HttpDelete("{id}")] // Added id parameter to the route
        public IActionResult DeleteGenre(int id)
        {
            _repo.Delete(id);
            return NoContent(); // 204 No Content for successful delete
        }
    }
}