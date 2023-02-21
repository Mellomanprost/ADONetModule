namespace DigitalLibrary.Practice
{
    public class Program
    {
        static void Main(string[] args)
        {
            var userRepos = new UserRepository();
            var bookRepos = new BookRepository();
            using (var db = new AppContext())
            {
                //userRepos.AddUser();
                var user1 = new User() { Name = "Leha", Email = "leha@mail.ru" };
                var user2 = new User() { Name = "Dima", Email = "dima@mail.ru" };
                db.Users.Add(user1);
                db.Users.Add(user2);

                var author = new Author() { Name = "Артур Конан", Surname = "Дойл", Books = null};
                var author2 = new Author() { Name = "Теодор", Surname = "Драйзер", Books = null};
                //db.Authors.AddRange(author,author2);
                //db.SaveChanges();


                var genres1 = new Genre() { Name = "Роман" };
                var genres2 = new Genre() { Name = "Детектив" };

                //db.Genres.AddRange(genres1, genres2);

                //db.SaveChanges();


                //bookRepos.AddBook("Стоик", 1982);
                //bookRepos.AddBook("Шерлок Холмс", 1986);

                var book1 = new Book() { Title = "Стоик", YearOfIssue = 1947, InStock = true};
                var book2 = new Book() { Title = "Шерлок Холмс", YearOfIssue = 1892, InStock = true};

                book1.Author = author2;
                book1.Genres.Add(genres1);
                book2.Author = author;
                book2.Genres.Add(genres2);

                db.Books.AddRange(book1, book2);
                db.SaveChanges();

                
            }
            bookRepos.GetOnHand();
        }
    }
}