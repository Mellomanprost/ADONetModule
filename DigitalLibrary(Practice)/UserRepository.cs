using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Practice
{
    public class UserRepository
    {
        #region Версия для заполнения через консоль

        //// Метод для выбора пользователя из БД по его идентификатору
        //public void SelectUser()
        //{
        //    Console.WriteLine("Введите ID пользователя:");
        //    var userId = Convert.ToInt32(Console.ReadLine());

        //    using (var db = new AppContext())
        //    {
        //        // Выбор пользователя в таблице
        //        var user = db.Users.FirstOrDefault(u => u.Id == userId);
        //        Console.WriteLine($"Пользователь с номером Id = {userId}:\n{user.Name}, {user.Email}");
        //    }
        //}

        //// Метод для выбора всех пользователей из БД
        //public void SelectAllUser()
        //{
        //    using (var db = new AppContext())
        //    {
        //        var allUsers = db.Users.ToList();
        //        Console.WriteLine();
        //        foreach (var user in allUsers)
        //        {
        //            Console.WriteLine($"{user.Id}. Имя пользователя: {user.Name}, Email: {user.Email}");
        //        }
        //    }
        //}

        //// Метод для добавления пользователя в БД
        //public void AddUser()
        //{
        //    Console.WriteLine("Введите имя пользователя:");
        //    var name = Console.ReadLine();
        //    Console.WriteLine("Введите электронный адрес:");
        //    var email = Console.ReadLine();

        //    using (var db = new AppContext())
        //    {
        //        var user = new User { Name = name, Email = email };
        //        db.Users.Add(user);
        //        db.SaveChanges();
        //    }
        //}

        //// Метод для удаления пользователя из БД
        //public void RemoveUser()
        //{
        //    Console.WriteLine("Введите имя пользователя для удаления:");
        //    var name = Console.ReadLine();

        //    using (var db = new AppContext())
        //    {
        //        var user = db.Users.Where(u => u.Name == name).ToList();
        //        db.Users.RemoveRange(user);
        //        db.SaveChanges();
        //    }
        //}

        //// Метод для обновления имени пользователя
        //public void UpdateUserName()
        //{
        //    Console.WriteLine("Введите ID пользователя, имя которого вы хотите изменить:");
        //    var id = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Введите новое имя:");
        //    var name = Console.ReadLine();

        //    using (var db = new AppContext())
        //    {
        //        var user = db.Users.FirstOrDefault(u => u.Id == id);
        //        user.Name = name;
        //        db.SaveChanges();
        //    }
        //}

        #endregion

        #region Версия для заполнение через компиляцию

        // Метод для выбора пользователя из БД по его идентификатору
        public void SelectUser(int userId)
        {
            using (var db = new AppContext())
            {
                // Выбор пользователя в таблице
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                Console.WriteLine($"Пользователь с номером Id = {userId}:\n{user.Name}, {user.Email}");
            }
        }

        // Метод для выбора всех пользователей из БД
        public void SelectAllUser()
        {
            using (var db = new AppContext())
            {
                var allUsers = db.Users.ToList();
                Console.WriteLine();
                foreach (var user in allUsers)
                {
                    Console.WriteLine($"{user.Id}. Имя пользователя: {user.Name}, Email: {user.Email}");
                }
            }
        }

        // Метод для добавления пользователя в БД
        public void AddUser(string name, string email)
        {
            using (var db = new AppContext())
            {
                var user = new User { Name = name, Email = email };
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        // Метод для удаления пользователя из БД
        public void RemoveUser(string name)
        {
            using (var db = new AppContext())
            {
                var user = db.Users.Where(u => u.Name == name).ToList();
                db.Users.RemoveRange(user);
                db.SaveChanges();
            }
        }

        // Метод для обновления имени пользователя
        public void UpdateUserName(int id, string name)
        {
            using (var db = new AppContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                user.Name = name;
                db.SaveChanges();
            }
        }

        #endregion
    }
}
