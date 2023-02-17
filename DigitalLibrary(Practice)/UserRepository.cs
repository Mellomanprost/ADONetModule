using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Practice
{
    public class UserRepository
    {

        // Метод для выбора пользователя из БД по его идентификатору
        public void SelectUser(int id)
        {
            using (var db = new AppContext())
            {
                //Выбор пользователей с ролью "Admin"
                //var admins = db.Users.Where(u => u.Id > 5).ToList();

                // Выбор первого пользователя в таблице
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                Console.WriteLine($"Пользователь с номером Id = {id}:\n{user.Name}, {user.Email}");
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

    }
}
