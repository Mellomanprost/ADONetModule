namespace DigitalLibrary.Practice.Variant2
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public int YearOfIssue { get; set; }
        public bool InStock { get; set; }

        // Навигационные свойства
        public User? User { get; set; }
    }
}
