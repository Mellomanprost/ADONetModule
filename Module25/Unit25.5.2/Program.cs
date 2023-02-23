namespace Unit25._5._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем контекст для добавления данных
            using (var db = new AppContext())
            {
                // Пересоздаем базу
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // Заполняем данными
                var company1 = new Company { Name = "SF" };
                var company2 = new Company { Name = "VK" };
                var company3 = new Company { Name = "FB" };
                db.Companies.AddRange(company1, company2, company3);

                var user1 = new User { Name = "Arthur", Role = "Admin", Company = company1 };
                var user2 = new User { Name = "Bob", Role = "Admin", Company = company2 };
                var user3 = new User { Name = "Clark", Role = "User", Company = company2 };
                var user4 = new User { Name = "Dan", Role = "User", Company = company3 };

                db.Users.AddRange(user1, user2, user3, user4);

                db.SaveChanges();
            }

            // Создаем контекст для выбора данных
            using (var db = new AppContext())
            {
                var usersQuery =
                    from user in db.Users
                    where user.CompanyId == 2
                    select user;

                var users = db.Users.Where(v => v.CompanyId == 2);

                var userCompany = db.Users.Select(v => v.Company);

                var firstUser = db.Users.First();

                var joinedCompanies = db.Users
                    .Join(db.Companies, c => c.CompanyId, p => p.Id, (p, c) => new { CompanyName = c.Name });

                var sumCompanies = db.Users.Sum(v => v.CompanyId);

                foreach (var user in users)
                {
                    Console.WriteLine($"users: {user.Name}");
                }

                foreach (var us in joinedCompanies)
                {
                    Console.WriteLine($"users: {us.CompanyName}");
                }

            }
        }
    }
}