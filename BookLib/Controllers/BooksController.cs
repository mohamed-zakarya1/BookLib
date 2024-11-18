using BookLib.DTOs;
using BookLib.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepo _repo;

        public BooksController(IBookRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _repo.GetAll();
            if (books == null || !books.Any())
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet("{id}")] // Corrected route to use id as a parameter
        public IActionResult GetById(int id)
        {
            var book = _repo.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook(BookDto bookDto) // Renamed method to be more descriptive
        {
            if (bookDto == null)
            {
                return BadRequest("Book data is required.");
            }
            _repo.AddBook(bookDto);
            return Ok(); // Assuming BookDto has an Id property
        }

        [HttpPut("{id}")] // Added id parameter to the route
        public IActionResult UpdateBook(int id, BookDto bookDto)
        {
            if (bookDto == null)
            {
                return BadRequest("Book data is required.");
            }
            _repo.Update(bookDto, id);
            return NoContent(); // 204 No Content for successful update
        }

        [HttpDelete("{id}")] // Added id parameter to the route
        public IActionResult DeleteBook(int id)
        {
            _repo.Delete(id);
            return NoContent(); // 204 No Content for successful delete
        }
    }
}