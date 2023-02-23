namespace DigitalLibrary.Practice
{
    public class Program
    {
        static void Main(string[] args)
        {
            var userRepos = new UserRepository();
            var bookRepos = new BookRepository();
            var genreRepos = new GenreRepository();
            var authorRepos = new AuthorRepository();

            Console.WriteLine("Добро пожаловать в систему управления электронной библиотекой!");
            
            using (var db = new AppContext())
            {
                #region Обычное заполнение БД
                // Заполнение пользователей
                var user1 = new User() { Name = "Leha", Email = "leha@mail.ru" };
                var user2 = new User() { Name = "Dima", Email = "dima@mail.ru" };
                var user3 = new User() { Name = "Sergey", Email = "sergey@mail.ru" };
                var user4 = new User() { Name = "Maxim", Email = "maxim@mail.ru" };
                var user5 = new User() { Name = "Vadim", Email = "vadim@mail.ru" };

                //Заполнение авторов
                var author = new Author() { Name = "Артур-Конан", Surname = "Дойл", Books = null };
                var author2 = new Author() { Name = "Теодор", Surname = "Драйзер", Books = null };
                var author3 = new Author() { Name = "Фредрик", Surname = "Бакман", Books = null };
                var author4 = new Author() { Name = "Даниэль", Surname = "Канеман", Books = null };
                var author5 = new Author() { Name = "Лю", Surname = "Цысинь", Books = null };

                // Заполнение жанров
                var genre1 = new Genre() { Name = "Роман" };
                var genre2 = new Genre() { Name = "Детектив" };
                var genre3 = new Genre() { Name = "Научпоп" };

                // Заполнение книг
                var book1 = new Book() { Title = "Стоик", YearOfIssue = 1947, InStock = true };
                var book2 = new Book() { Title = "Шерлок Холмс", YearOfIssue = 1892, InStock = true };
                var book3 = new Book() { Title = "Думай медленно... Решай быстро", YearOfIssue = 2011, InStock = true };
                var book4 = new Book() { Title = "Задача трех тел", YearOfIssue = 2006, InStock = true };
                var book5 = new Book() { Title = "Тревожные люди", YearOfIssue = 2019, InStock = true };
                var book6 = new Book() { Title = "Вторая жизнь Уве", YearOfIssue = 2012, InStock = true };

                // Добавление данных в БД
                db.Users.AddRange(user1, user2, user3, user4, user5);
                db.Genres.AddRange(genre1, genre2, genre3);
                db.Books.AddRange(book1, book2, book3, book4, book5, book6);
                db.Authors.AddRange(author, author2, author3, author4, author5);

                // Связывание книг с авторами и жанрами
                book1.Author = author2;
                book1.Genre = genre1;

                book2.Author = author;
                book2.Genre = genre2;

                book3.Author = author4;
                book3.Genre = genre3;

                book4.Author = author5;
                book4.Genre = genre1;

                book5.Author = author3;
                book5.Genre = genre1;

                book6.Author = author3;
                book6.Genre = genre1;

                // Сохранение данных в БД
                db.SaveChanges();




                #endregion

                #region Заполнение БД через методы

                //// Заполнение пользователей
                //userRepos.AddUser("Leha", "leha@mail.ru");
                //userRepos.AddUser("Dima", "dima@mail.ru");
                //userRepos.AddUser("Sergey", "sergey@mail.ru");
                //userRepos.AddUser("Maxim", "maxim@mail.ru");
                //userRepos.AddUser("Vadim", "vadim@mail.ru");

                //// Заполнение авторов
                //authorRepos.AddAuthor("Артур-Конан", "Дойл");
                //authorRepos.AddAuthor("Теодор", "Драйзер");
                //authorRepos.AddAuthor("Фредрик", "Бакман");
                //authorRepos.AddAuthor("Даниэль", "Канеман");
                //authorRepos.AddAuthor("Лю", "Цысинь");

                //// Заполнение жанров
                //genreRepos.AddGenre("Роман");
                //genreRepos.AddGenre("Детектив");
                //genreRepos.AddGenre("Научпоп");

                //// Заполнение книг
                //bookRepos.AddBook("Стоик", 1947);
                //bookRepos.AddBook("Шерлок Холмс", 1892);
                //bookRepos.AddBook("Думай медленно... Решай быстро", 2011);
                //bookRepos.AddBook("Задача трех тел", 2006);
                //bookRepos.AddBook("Тревожные люди", 2019);
                //bookRepos.AddBook("Вторая жизнь Уве", 2012);

                //book2.Author = db.Authors.FirstOrDefault(a => a.Id == 1);
                //book2.Genre = db.Genres.FirstOrDefault(g => g.Id == 2);

                //book3.Author = db.Authors.FirstOrDefault(a => a.Id == 4);
                //book3.Genre = db.Genres.FirstOrDefault(g => g.Id == 3);

                //book4.Author = db.Authors.FirstOrDefault(a => a.Id == 5);
                //book4.Genre = db.Genres.FirstOrDefault(g => g.Id == 1);

                //book5.Author = db.Authors.FirstOrDefault(a => a.Id == 3);
                //book5.Genre = db.Genres.FirstOrDefault(g => g.Id == 1);

                //book6.Author = db.Authors.FirstOrDefault(a => a.Id == 3);
                //book6.Genre = db.Genres.FirstOrDefault(g => g.Id == 1);

                #endregion


                // Метод для взятия книги на руки
                //bookRepos.GetOnHand("leha@mail.ru", "Стоик");

                // 1.
                //bookRepos.GetBooksListInPeriod("Детектив", 1890, 1945);

                // 2.
                //bookRepos.CountBooksFromAuthor("Драйзер");

                // 3.
                //bookRepos.CountBooksFromGenre("Роман");

                // 4.
                //bookRepos.ContainsBookInLibrary("Драйзер", "Титан");

                // 5.
                //bookRepos.IsUserBookOnHand("Шерлок Холмс", "Leha");

                // 6.
                //bookRepos.CountBooksOnUserHand("Leha");

                // 7.
                //bookRepos.GetNewestBook();

                // 8.
                //bookRepos.GetAllBooksSortedByTitle();

                // 9.
                //bookRepos.GetAllBooksSortedDescByYear();
            }
            //bookRepos.GetOnHand();
        }
    }
}