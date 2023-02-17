namespace ProjectWithEntityFramework
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                // Выбор пользователей с ролью "Admin"
                var admins = db.Users.Where(user => user.Role == "Admin").ToList();
                foreach (var item in admins)
                {
                    
                }
                //db.Users.RemoveRange(admins);

                // Выбор первого пользователя в таблице
                //var firstUser = db.Users.FirstOrDefault();
                //firstUser.Email = "simpleemail@gmail.com";
                db.SaveChanges();
            }

        }
    }
}