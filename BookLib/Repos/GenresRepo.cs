using BookLib.Data;
using BookLib.Data.Models;
using BookLib.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BookLib.Repos
{
    public class GenresRepo : IGenresRepo
    {
        private readonly AppDbContext _context;
        public GenresRepo(AppDbContext context)
        {
            _context = context;
        }
        public void AddBook(GenreDto genreDto)
        {
            var obj = new Genre
            {
                Name = genreDto.Name,
                Books = _context.Books.Where(x => genreDto.BooksId.Contains(x.Id)).ToList(),
            };
            _context.Genres.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var genres = _context.Genres.FirstOrDefault(x => x.Id == id);
            _context.Genres.Remove(genres);
            _context.SaveChanges();
        }

        public IList<GenreDto> GetAll()
        {
            var genres = _context.Genres.Include(x => x.Books).Select(x=> new GenreDto
            {
                Name = x.Name,
                Books = x.Books.Select(x => x.Title).ToList(),
            }).ToList();
            return genres;
        }

        public GenreDto GetById(int id)
        {
            var genres = _context.Genres.Include(x => x.Books).FirstOrDefault(x => x.Id == id);
            return new GenreDto
            {
                Name = genres.Name,
                Books = genres.Books.Select(x => x.Title).ToList(),
            };
        }

        public void Update(GenreDto genreDto, int id)
        {
            var genres = _context.Genres.Include(x => x.Books).FirstOrDefault(y => y.Id == id);
            genres.Name = genreDto.Name;
            genres.Books = _context.Books.Where(x => genreDto.BooksId.Contains(x.Id)).ToList();
            _context.Genres.Update(genres);
            _context.SaveChanges();
        }
    }
}
