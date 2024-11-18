using BookLib.DTOs;
using BookLib.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepo _repo;

        public AuthorsController(IAuthorRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authors = _repo.GetAll();
            if (authors == null || !authors.Any())
            {
                return NotFound();
            }
            return Ok(authors);
        }

        [HttpGet("{id}")] // Corrected route to use id as a parameter
        public IActionResult GetById(int id)
        {
            var author = _repo.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public IActionResult AddAuthor(AuthorDto authorDto) // Renamed method to be more descriptive
        {
            if (authorDto == null)
            {
                return BadRequest("Author data is required.");
            }
            _repo.AddBook(authorDto); // Assuming this method adds the author
            return Ok(); // Assuming AuthorDto has an Id property
        }

        [HttpPut("{id}")] // Added id parameter to the route
        public IActionResult UpdateAuthor(int id, AuthorDto authorDto)
        {
            if (authorDto == null)
            {
                return BadRequest("Author data is required.");
            }
            _repo.Update(authorDto, id);
            return NoContent(); // 204 No Content for successful update
        }

        [HttpDelete("{id}")] // Added id parameter to the route
        public IActionResult DeleteAuthor(int id)
        {
            _repo.Delete(id);
            return NoContent(); // 204 No Content for successful delete
        }
    }
}