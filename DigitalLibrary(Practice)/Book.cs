using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DigitalLibrary.Practice
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int YearOfIssue { get; set; }
        public bool InStock { get; set; }

        // Внешние ключи
        public int AuthorId { get; set; }
        //public int UserId { get; set; }

        // Навигационные свойства
        public Author? Author { get; set; }
        public Genre? Genre { get; set; }
        public User? User { get; set; }
    }
}
