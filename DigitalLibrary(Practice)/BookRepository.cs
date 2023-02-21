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
        //public void RemoveUser()
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
                var book = new Book { Title = title, YearOfIssue = yearofissue };
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        // Метод для удаления книги из БД
        public void RemoveUser(string title)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.Where(b => b.Title == title).ToList();
                db.Books.RemoveRange(book);
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
                    user.BooksOnHand += bookTitle + " ";
                    book.InStock = false;
                    db.SaveChanges();
                }
                else
                    Console.WriteLine("Такой книги нет в наличии!");
            }
        }

        // Метод для получения списка книг определенного жанра и вышедших между определенными годами
        public void GetBooksListInPeriod()
        {

        }


        #endregion
    }
}
