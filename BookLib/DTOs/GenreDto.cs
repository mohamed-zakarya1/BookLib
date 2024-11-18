namespace BookLib.DTOs
{
    public class GenreDto
    {
        public string? Name { get; set; }
        public IList<int>? BooksId { get; set; }
        public IList<string>? Books { get; set; }
    }
}
