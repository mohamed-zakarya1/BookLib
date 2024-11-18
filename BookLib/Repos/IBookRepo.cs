using BookLib.Data.Models;
using BookLib.DTOs;

namespace BookLib.Repos
{
    public interface IBookRepo
    {
        IList<BookDto> GetAll();
        BookDto GetById(int id);
        void Update(BookDto bookDto, int id);
        void Delete(int id);
        void AddBook(BookDto bookDto);
    }
}
