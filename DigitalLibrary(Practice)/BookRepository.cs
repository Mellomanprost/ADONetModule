using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Practice
{
    public class BookRepository
    {
        #region Версия для заполнения через консоль

        //// Метод для выбора книги из БД по её идентификатору
        //public void SelectBook()
        //{
        //    Console.WriteLine("Введите Id книги:");
        //    var id = Convert.ToInt32(Console.ReadLine());

        //    using (var db = new AppContext())
        //    {
        //        // Выбор книги в таблице
        //        var book = db.Books.FirstOrDefault(u => u.Id == id);
        //        Console.WriteLine($"Книга с номером Id = {id} - \"{book.Title}\", ({book.YearOfIssue})");
        //    }
        //}

        //// Метод для выбора всех книг из БД
        //public void SelectAllBooks()
        //{
        //    using (var db = new AppContext())
        //    {
        //        var allBooks = db.Books.ToList();
        //        Console.WriteLine("Список всех книг:");
        //        foreach (var book in allBooks)
        //        {
        //            Console.WriteLine($"{book.Id}. \"{book.Title}\", ({book.YearOfIssue})");
        //        }
        //    }
        //}

        //// Метод для добавления книги в БД
        //public void AddBook()
        //{
        //    Console.WriteLine("Введите название книги:");
        //    var title = Console.ReadLine();
        //    Console.WriteLine("Введите год выпуска книги:");
        //    var yearofissue = Convert.ToInt32(Console.ReadLine());

        //    using (var db = new AppContext())
        //    {
        //        var book = new Book { Title = title, YearOfIssue = yearofissue };
        //        db.Books.Add(book);
        //        db.SaveChanges();
        //    }
        //}

        //// Метод для удаления книги из БД
        //public void RemoveBook()
        //{
        //    Console.WriteLine("Введите название книги, которую хотите удалить:");
        //    var title = Console.ReadLine();

        //    using (var db = new AppContext())
        //    {
        //        var book = db.Books.Where(b => b.Title == title).ToList();
        //        db.Books.RemoveRange(book);
        //        db.SaveChanges();
        //    }
        //}

        //// Метод для обновления года выпуска книги по Id
        //public void UpdateYearOfIssue()
        //{
        //    Console.WriteLine("Введите Id книги, год выпуска которой нужно изменить:");
        //    var id = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Введите новый год выпуска:");
        //    var yearofissue = Convert.ToInt32(Console.ReadLine());

        //    using (var db = new AppContext())
        //    {
        //        var book = db.Books.FirstOrDefault(b => b.Id == id);
        //        book.YearOfIssue = yearofissue;
        //        db.SaveChanges();
        //    }
        //}

        //// Метод для выдачи книги пользователю на руки
        //public void GetOnHand()
        //{
        //    Console.WriteLine("Введите свой электронный адрес:");
        //    var email = Console.ReadLine();
        //    if (email == null)
        //        Console.WriteLine("Ошибка! Электронный адрес не указан!");

        //    Console.WriteLine("Введите название книги:");
        //    var bookTitle = Console.ReadLine();
        //    if (bookTitle == null)
        //        Console.WriteLine("Ошибка! Название книги не указано!");

        //    using (var db = new AppContext())
        //    {
        //        var book = db.Books.FirstOrDefault(b => b.Title == bookTitle);
        //        var user = db.Users.FirstOrDefault(u => u.Email == email);
        //        if (book != null && book.InStock)
        //        {
        //            user.BooksOnHand += bookTitle + " ";
        //            //book.UserId = user.Id;
        //            book.InStock = false;
        //            db.SaveChanges();
        //        }
        //        else
        //            Console.WriteLine("Такой книги нет в наличии!");
        //    }
        //}

        //// Метод для получения списка книг определенного жанра и вышедших между определенными годами
        //public void GetBooksListInPeriod()
        //{

        //}

        #endregion

        #region Версия для заполнения через компиляцию

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
        public void AddBook(string title, int yearofissue)
        {
            using (var db = new AppContext())
            {
                var book = new Book { Title = title, YearOfIssue = yearofissue, InStock = true};
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        // Метод для удаления книги из БД
        public void RemoveBook(string title)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(b => b.Title == title);
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
                    user.BooksOnHand += bookTitle + " ";    //добавляет книгу пользователю
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
                    .Where(b => b.YearOfIssue > minYear && b.YearOfIssue < maxYear && b.Genre.Name != null && b.Genre.Name == genre)
                    .ToList();
                Console.WriteLine();
                foreach (var book in books)
                {
                    Console.WriteLine(book.Title + " " + book.Genre.Name);
                }
            }
        }

        // 2. Метод для получения количества книг определенного автора в библиотеке
        public void CountBooksFromAuthor(string author)
        {
            using (var db = new AppContext())
            {
                var countBooks = db.Books
                    .Where(b => b.Author.Surname != null && b.Author.Surname == author)
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
                    .Where(b => b.Genre.Name != null && b.Genre.Name == genre)
                    .Count();
                Console.WriteLine($"Количество всех книг жанра {genre}: {countBooks}");
            }
        }

        // 4. Метод для получения булевого флага о том, есть ли книга определенного автора и с определенным названием в библиотеке
        public bool ContainsBookInLibrary(string author, string title)
        {
            using (var db = new AppContext())
            {
                var contTitle = db.Books.Select(b => b.Title).Contains(title);
                var contAuthor = db.Books
                    .Join(db.Authors, b => b.AuthorId, a => a.Id, (a, b) => new { AuthorSurname = b.Surname })
                    .Select(b => b.AuthorSurname)
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
                    .Select(b => b.BooksOnHand).Contains(title);
                if (booksOnHand)
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
                    var countBooks = userName.BooksOnHand.Count();
                    Console.WriteLine($"Количество книг у пользователя {userName.Name}: {countBooks}");
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

        #endregion
    }
}
