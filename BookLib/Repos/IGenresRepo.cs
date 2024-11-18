using BookLib.DTOs;

namespace BookLib.Repos
{
    public interface IGenresRepo
    {
        IList<GenreDto> GetAll();
        GenreDto GetById(int id);
        void Update(GenreDto genreDto, int id);
        void Delete(int id);
        void AddBook(GenreDto genreDto);
    }
}
