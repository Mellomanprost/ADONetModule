using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Practice
{
    public class GenreRepository
    {
        #region Версия для заполнения через консоль

        //// Метод для выбора жанра из БД по его идентификатору
        //public void SelectGenre()
        //{
        //    Console.WriteLine("Введите Id жанра:");
        //    var genreId = Convert.ToInt32(Console.ReadLine());

        //    using (var db = new AppContext())
        //    {
        //        // Выбор автора в таблице
        //        var genre = db.Genres.FirstOrDefault(u => u.Id == genreId);
        //        Console.WriteLine($"Жанр с номером Id = {genreId}: {genre.Name}");
        //    }
        //}

        //// Метод для выбора всех жанров из БД
        //public void SelectAllGenres()
        //{
        //    using (var db = new AppContext())
        //    {
        //        var allGenres = db.Genres.ToList();
        //        Console.WriteLine();
        //        foreach (var genre in allGenres)
        //        {
        //            Console.WriteLine($"{genre.Id}. Название жанра: {genre.Name}");
        //        }
        //    }
        //}

        //// Метод для добавления жанра в БД
        //public void AddGenre()
        //{
        //    Console.WriteLine("Введите название жанра:");
        //    var genreName = Console.ReadLine();

        //    using (var db = new AppContext())
        //    {
        //        var genre = new Genre() { Name = genreName };
        //        db.Genres.Add(genre);
        //        db.SaveChanges();
        //    }
        //}

        //// Метод для удаления жанра из БД
        //public void RemoveGenre()
        //{
        //    Console.WriteLine("Введите название жанра для удаления:");
        //    var genreName = Console.ReadLine();

        //    using (var db = new AppContext())
        //    {
        //        var genre = db.Genres.Where(u => u.Name == genreName).ToList();
        //        db.Genres.RemoveRange(genre);
        //        db.SaveChanges();
        //    }
        //}

        //// Метод для обновления названия жанра
        //public void UpdateGenreName()
        //{
        //    Console.WriteLine("Введите Id жанра, название которого вы хотите изменить:");
        //    var id = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Введите новое название:");
        //    var genreName = Console.ReadLine();

        //    using (var db = new AppContext())
        //    {
        //        var genre = db.Genres.FirstOrDefault(u => u.Id == id);
        //        genre.Name = genreName;
        //        db.SaveChanges();
        //    }
        //}

        #endregion

        #region Версия для заполнения через компиляцию

        // Метод для выбора жанра из БД по его идентификатору
        public void SelectGenre(int genreId)
        {
            using (var db = new AppContext())
            {
                // Выбор автора в таблице
                var genre = db.Genres.FirstOrDefault(u => u.Id == genreId);
                Console.WriteLine($"Жанр с номером Id = {genreId}: {genre.Name}");
            }
        }

        // Метод для выбора всех жанров из БД
        public void SelectAllGenres()
        {
            using (var db = new AppContext())
            {
                var allGenres = db.Genres.ToList();
                Console.WriteLine();
                foreach (var genre in allGenres)
                {
                    Console.WriteLine($"{genre.Id}. Название жанра: {genre.Name}");
                }
            }
        }

        // Метод для добавления жанра в БД
        public void AddGenre(string genreName)
        {
            using (var db = new AppContext())
            {
                var genre = new Genre() { Name = genreName };
                db.Genres.Add(genre);
                db.SaveChanges();
            }
        }

        // Метод для удаления жанра из БД
        public void RemoveGenre(string genreName)
        {
            using (var db = new AppContext())
            {
                var genre = db.Genres.Where(u => u.Name == genreName).ToList();
                db.Genres.RemoveRange(genre);
                db.SaveChanges();
            }
        }

        // Метод для обновления названия жанра
        public void UpdateGenreName(int id, string genreName)
        {
            using (var db = new AppContext())
            {
                var genre = db.Genres.FirstOrDefault(u => u.Id == id);
                genre.Name = genreName;
                db.SaveChanges();
            }
        }

        #endregion
    }
}
