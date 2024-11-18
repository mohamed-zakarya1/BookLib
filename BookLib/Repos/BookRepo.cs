using BookLib.Data;
using BookLib.Data.Models;
using BookLib.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BookLib.Repos
{
    public class BookRepo : IBookRepo
    {
        private readonly AppDbContext _context;
        public BookRepo(AppDbContext context)
        {
            _context = context;
        }
        public void AddBook(BookDto bookDto)
        {
            var obj = new Book
            {
                Title = bookDto.Title,
                Published_year = bookDto.Published_year,
                Authors = _context.Authors.Where(x => bookDto.AuthorsId.Contains(x.Id)).ToList(),
                Genres = _context.Genres.Where(x => bookDto.GenresId.Contains(x.Id)).ToList()
            };
            _context.Books.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public IList<BookDto> GetAll()
        {
            var book = _context.Books
            .Include(x => x.Authors)
            .Include(x => x.Genres)
            .Select(x => new BookDto
            {
                Title = x.Title,
                Published_year = x.Published_year,
                Genres = x.Genres.Select(x => x.Name).ToList(),
                Authors = x.Authors.Select(x => x.Name).ToList()
            }).ToList();
            return book;
        }

        public BookDto GetById(int id)
        {
            var book = _context.Books
            .Include(x => x.Authors)
            .Include(x => x.Genres)
            .FirstOrDefault(x => x.Id == id);
            return new BookDto
            {
                Title = book.Title,
                Published_year = book.Published_year,
                Genres = book.Genres.Select(x => x.Name).ToList(),
                Authors = book.Authors.Select(x => x.Name).ToList()
            };
        }

        public void Update(BookDto bookDto, int id)
        {
            var book = _context.Books
            .Include(x => x.Authors)
            .Include(x => x.Genres)
            .FirstOrDefault(x => x.Id == id);
            book.Title = bookDto.Title;
            book.Published_year = bookDto.Published_year;
            book.Authors = _context.Authors.Where(x => bookDto.AuthorsId.Contains(id)).ToList();
            book.Genres = _context.Genres.Where(x => bookDto.GenresId.Contains(id)).ToList();
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}
