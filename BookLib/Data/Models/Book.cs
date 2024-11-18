namespace BookLib.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime Published_year { get; set; }
        public IList<Author>? Authors { get; set; }
        public IList<Genre>? Genres { get; set; }
    }
}
