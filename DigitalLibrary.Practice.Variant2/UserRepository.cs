namespace DigitalLibrary.Practice.Variant2
{
    public class UserRepository
    {
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
                var user = db.Users.First(u => u.Name == name);
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        // Метод для обновления имени пользователя
        public void UpdateUserName(int id, string name)
        {
            using (var db = new AppContext())
            {
                var user = db.Users.First(u => u.Id == id);
                user.Name = name;
                db.SaveChanges();
            }
        }
    }
}
