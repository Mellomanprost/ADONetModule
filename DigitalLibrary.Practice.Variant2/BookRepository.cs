namespace DigitalLibrary.Practice.Variant2
{
    public class BookRepository
    {
        // Метод для выбора книги из БД по её идентификатору
        public void SelectBook(int id)
        {
            using (var db = new AppContext())
            {
                // Выбор книги в таблице
                var book = db.Books.FirstOrDefault(u => u.Id == id);
                Console.WriteLine($"Книга с номером Id = {id} - \"{book.Title}\", ({book.YearOfIssue})");
            }
        }

        // Метод для выбора всех книг из БД
        public void SelectAllBooks()
        {
            using (var db = new AppContext())
            {
                var allBooks = db.Books.ToList();
                Console.WriteLine("Список всех книг:");
                foreach (var book in allBooks)
                {
                    Console.WriteLine($"{book.Id}. \"{book.Title}\", ({book.YearOfIssue})");
                }
            }
        }

        // Метод для добавления книги в БД
        public void AddBook(string title, int yearofissue, string author, string genre)
        {
            using (var db = new AppContext())
            {
                var book = new Book { Title = title, YearOfIssue = yearofissue, Author = author, Genre = genre, InStock = true };
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        // Метод для удаления книги из БД
        public void RemoveBook(string title, string author)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(b => b.Title == title && b.Author == author);
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        // Метод для обновления года выпуска книги по Id
        public void UpdateYearOfIssue(int id, int yearofissue)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(b => b.Id == id);
                book.YearOfIssue = yearofissue;
                db.SaveChanges();
            }
        }

        // Метод для выдачи книги пользователю на руки
        public void GetOnHand(string email, string bookTitle)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(b => b.Title == bookTitle);
                var user = db.Users.FirstOrDefault(u => u.Email == email);
                if (book != null && book.InStock)
                {
                    user.BooksOnHand += bookTitle + ";";    //добавляет книгу пользователю
                    book.InStock = false;   //изменяет графу в наличии
                    book.User = user;   //добавляет информацию о пользователе в таблицу книги
                    db.SaveChanges();
                }
                else
                    Console.WriteLine("Такой книги нет в наличии!");
            }
        }

        // 1. Метод для получения списка книг определенного жанра и вышедших между определенными годами
        public void GetBooksListInPeriod(string genre, int minYear, int maxYear)
        {
            using (var db = new AppContext())
            {
                var books = db.Books
                    .Where(b => b.YearOfIssue > minYear && b.YearOfIssue < maxYear && b.Genre == genre)
                    .ToList();
                Console.WriteLine();
                foreach (var book in books)
                {
                    Console.WriteLine(book.Title + " " + book.Genre);
                }
            }
        }

        // 2. Метод для получения количества книг определенного автора в библиотеке
        public void CountBooksFromAuthor(string author)
        {
            using (var db = new AppContext())
            {
                var countBooks = db.Books
                    .Where(b => b.Author == author)
                    .Count();
                Console.WriteLine($"Количество всех книг автора {author}: {countBooks}");
            }
        }

        // 3. Метод для получения количества книг определенного жанра в библиотеке
        public void CountBooksFromGenre(string genre)
        {
            using (var db = new AppContext())
            {
                var countBooks = db.Books
                    .Where(b => b.Genre == genre)
                    .Count();
                Console.WriteLine($"Количество всех книг жанра {genre}: {countBooks}");
            }
        }

        // 4. Метод для получения булевого флага о том, есть ли книга определенного автора и с определенным названием в библиотеке
        public bool ContainsBookInLibrary(string author, string title)
        {
            using (var db = new AppContext())
            {
                var contTitle = db.Books
                    .Select(b => b.Title)
                    .Contains(title);
                var contAuthor = db.Books
                    .Select(b => b.Author)
                    .Contains(author);
                if (contAuthor && contTitle)
                {
                    Console.WriteLine($"Книга {title} автора {author} есть в библиотеке!");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Книги {title} автора {author} нету в библиотеке!");
                    return false;
                }
            }
        }

        // 5. Метод для получаения булевого флага о том, есть ли определенная книга на руках у пользователя
        public bool IsUserBookOnHand(string title, string user)
        {
            using (var db = new AppContext())
            {
                var booksOnHand = db.Users
                    .Where(u => u.Name == user)
                    .Select(b => b.BooksOnHand)
                    .ToList()
                    .LastOrDefault()
                    .Split(';');

                var flag = booksOnHand.Contains(title);

                if (flag)
                {
                    Console.WriteLine($"Книга {title} есть на руках у пользователя {user}!");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Книги {title} нету на руках у пользователя {user}");
                    return false;
                }
            }
        }

        // 6.Метод для получения количества книг на руках у пользователя
        public void CountBooksOnUserHand(string user)
        {
            using (var db = new AppContext())
            {
                var userName = db.Users
                    .FirstOrDefault(u => u.Name == user);
                if (userName != null && userName.BooksOnHand != null)
                {
                    var booksOnHand = db.Users
                        .Where(u => u.Name == user)
                        .Select(b => b.BooksOnHand)
                        .ToList()
                        .LastOrDefault()
                        .Split(';');
                    var count = booksOnHand.Count() - 1;    // отнимаем 1, т.к. последний элемент всегда пустой
                    Console.WriteLine($"Количество книг у пользователя {userName.Name}: {count}");
                }
                else
                    Console.WriteLine("Ошибка!");
            }
        }

        // 7. Метод для получения последней вышедшей книги.
        public void GetNewestBook()
        {
            using (var db = new AppContext())
            {
                int maxYear = db.Books
                    .Max(b => b.YearOfIssue);
                var book = db.Books
                    .Where(b => b.YearOfIssue == maxYear)
                    .ToList();
                foreach (var b in book)
                {
                    Console.WriteLine($"Последняя вышедшая книга - {b.Title}");
                }
            }
        }

        // 8. Метод для получения списка всех книг, отсортированноого в алфавитном порядке по названию
        public void GetAllBooksSortedByTitle()
        {
            using (var db = new AppContext())
            {
                var booksList = db.Books.OrderBy(b => b.Title).ToList();
                foreach (var book in booksList)
                {
                    Console.WriteLine($"{book.Title}");
                }
            }
        }

        // 9. Метод для получения списка всех книг, отсортированного в порядке убывания года их выхода
        public void GetAllBooksSortedDescByYear()
        {
            using (var db = new AppContext())
            {
                var booksList = db.Books.OrderByDescending(b => b.YearOfIssue);
                foreach (var book in booksList)
                {
                    Console.WriteLine($"{book.YearOfIssue}");
                }
            }
        }
    }
}
