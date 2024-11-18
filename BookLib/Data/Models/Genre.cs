namespace BookLib.Data.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IList<Book>? Books { get; set; }
    }
}
