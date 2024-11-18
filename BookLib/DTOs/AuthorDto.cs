namespace BookLib.DTOs
{
    public class AuthorDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNum { get; set; }
        public IList<int>? BooksId { get; set; }
        public IList<string>? Books { get; set; }
    }
}
