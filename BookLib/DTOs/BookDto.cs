namespace BookLib.DTOs
{
    public class BookDto
    {
        public string? Title { get; set; }
        public DateTime Published_year { get; set; }
        public IList<int>? GenresId { get; set; }
        public IList<int>? AuthorsId { get; set; }
        public IList<string>? Genres { get; set; }
        public IList<string>? Authors { get; set; }
    }
}
