using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Practice
{
    public class AuthorRepository
    {
        #region Версия для заполнения через консоль

        //// Метод для выбора автора из БД по его идентификатору
        //public void SelectAuthor()
        //{
        //    Console.WriteLine("Введите Id автора:");
        //    var authorId = Convert.ToInt32(Console.ReadLine());

        //    using (var db = new AppContext())
        //    {
        //        // Выбор автора в таблице
        //        var author = db.Authors.FirstOrDefault(u => u.Id == authorId);
        //        Console.WriteLine($"Автор с номером Id = {authorId}: {author.Name}, {author.Surname}");
        //    }
        //}

        //// Метод для выбора всех авторов из БД
        //public void SelectAllAuthors()
        //{
        //    using (var db = new AppContext())
        //    {
        //        var allAuthors = db.Authors.ToList();
        //        Console.WriteLine();
        //        foreach (var author in allAuthors)
        //        {
        //            Console.WriteLine($"{author.Id}. Имя автора: {author.Name}, Фамилия автора: {author.Surname}");
        //        }
        //    }
        //}

        //// Метод для добавления автора в БД
        //public void AddAuthor()
        //{
        //    Console.WriteLine("Введите имя автора:");
        //    var name = Console.ReadLine();
        //    Console.WriteLine("Введите фамилию автора:");
        //    var surname = Console.ReadLine();

        //    using (var db = new AppContext())
        //    {
        //        var author = new Author { Name = name, Surname = surname };
        //        db.Authors.Add(author);
        //        db.SaveChanges();
        //    }
        //}

        //// Метод для удаления автора из БД
        //public void RemoveAuthor()
        //{
        //    Console.WriteLine("Введите имя автора для удаления:");
        //    var name = Console.ReadLine();

        //    using (var db = new AppContext())
        //    {
        //        var author = db.Authors.Where(u => u.Name == name).ToList();
        //        db.Authors.RemoveRange(author);
        //        db.SaveChanges();
        //    }
        //}

        //// Метод для обновления имени пользователя
        //public void UpdateAuthorName()
        //{
        //    Console.WriteLine("Введите Id автора, имя которого вы хотите изменить:");
        //    var id = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Введите новое имя:");
        //    var name = Console.ReadLine();

        //    using (var db = new AppContext())
        //    {
        //        var author = db.Authors.FirstOrDefault(u => u.Id == id);
        //        author.Name = name;
        //        db.SaveChanges();
        //    }
        //}

        #endregion

        #region Версия для заполнения через компиляцию

        // Метод для выбора автора из БД по его идентификатору
        public void SelectAuthor(int authorId)
        {
            using (var db = new AppContext())
            {
                // Выбор автора в таблице
                var author = db.Authors.FirstOrDefault(u => u.Id == authorId);
                Console.WriteLine($"Автор с номером Id = {authorId}: {author.Name}, {author.Surname}");
            }
        }

        // Метод для выбора всех авторов из БД
        public void SelectAllAuthors()
        {
            using (var db = new AppContext())
            {
                var allAuthors = db.Authors.ToList();
                Console.WriteLine();
                foreach (var author in allAuthors)
                {
                    Console.WriteLine($"{author.Id}. Имя автора: {author.Name}, Фамилия автора: {author.Surname}");
                }
            }
        }

        // Метод для добавления автора в БД
        public void AddAuthor(string name, string surname)
        {
            using (var db = new AppContext())
            {
                var author = new Author { Name = name, Surname = surname };
                db.Authors.Add(author);
                db.SaveChanges();
            }
        }

        // Метод для удаления автора из БД
        public void RemoveAuthor(string name)
        {
            using (var db = new AppContext())
            {
                var author = db.Authors.Where(u => u.Name == name).ToList();
                db.Authors.RemoveRange(author);
                db.SaveChanges();
            }
        }

        // Метод для обновления имени пользователя
        public void UpdateAuthorName(int id, string name)
        {
            using (var db = new AppContext())
            {
                var author = db.Authors.FirstOrDefault(u => u.Id == id);
                author.Name = name;
                db.SaveChanges();
            }
        }


        #endregion

    }
}
