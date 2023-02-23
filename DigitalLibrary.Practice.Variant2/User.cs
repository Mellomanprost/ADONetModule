namespace DigitalLibrary.Practice.Variant2
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? BooksOnHand { get; set; }

        public List<Book>? Books { get; set; } = new List<Book>();
    }
}
