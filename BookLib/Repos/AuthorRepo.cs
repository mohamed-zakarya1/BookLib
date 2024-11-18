using BookLib.Data;
using BookLib.Data.Models;
using BookLib.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BookLib.Repos
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly AppDbContext _context;
        public AuthorRepo(AppDbContext context) 
        {
            _context = context;
        }
        public void AddBook(AuthorDto authorDto)
        {
            var obj = new Author
            {
                Name = authorDto.Name,
                PhoneNum = authorDto.PhoneNum,
                Email = authorDto.Email,
                Books = _context.Books.Where(x => authorDto.BooksId.Contains(x.Id)).ToList(),
            };
            _context.Authors.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var authors = _context.Authors.FirstOrDefault(x => x.Id == id); 
            _context.Authors.Remove(authors);
            _context.SaveChanges();
        }

        public IList<AuthorDto> GetAll()
        {
            var books = _context.Authors.Include(x => x.Books).Select(x => new AuthorDto
            {
                Name = x.Name,
                PhoneNum = x.PhoneNum,
                Email = x.Email,
                Books = x.Books.Select(x => x.Title).ToList(),
            }).ToList();
            return books;
        }

        public AuthorDto GetById(int id)
        {
            var author = _context.Authors.Include(x => x.Books).FirstOrDefault(x => x.Id == id);
            return new AuthorDto
            {
                Name = author.Name,
                PhoneNum = author.PhoneNum,
                Email = author.Email,
                Books = author.Books.Select(x => x.Title).ToList(),
            };
        }

        public void Update(AuthorDto authorDto, int id)
        {
            var author = _context.Authors.Include(x => x.Books).FirstOrDefault(x => x.Id == id);
            author.Name = authorDto.Name;
            author.PhoneNum = authorDto.PhoneNum;
            author.Email = authorDto.Email;
            author.Books = _context.Books.Where(x => authorDto.BooksId.Contains(x.Id)).ToList();
            _context.Authors.Update(author);
            _context.SaveChanges();
        }
    }
}
