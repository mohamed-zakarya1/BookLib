using BookLib.DTOs;

namespace BookLib.Repos
{
    public interface IAuthorRepo
    {
        IList<AuthorDto> GetAll();
        AuthorDto GetById(int id);
        void Update(AuthorDto authorDto, int id);
        void Delete(int id);
        void AddBook(AuthorDto authorDto);
    }
}
