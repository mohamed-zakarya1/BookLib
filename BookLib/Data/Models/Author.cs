namespace BookLib.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNum { get; set; }
        public IList<Book>? Books { get; set; }
    }
}
