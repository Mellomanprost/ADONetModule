namespace ProjectWithEntityFramework
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                //var user1 = new User { Name = "Arthur", Role = "Admin" };
                //var user2 = new User { Name = "Bob", Role = "Admin" };
                //var user3 = new User { Name = "Clark", Role = "User" };
                //var user4 = new User { Name = "Dan", Role = "User" };

                //db.Users.Add(user2);
                //db.SaveChanges();

                //db.Users.AddRange(user1, user3, user4);

                //var user1Creds = new UserCredential { Login = "ArthurL", Password = "qwerty123" };
                //var user2Creds = new UserCredential { Login = "BobJ", Password = "asdfgh585" };
                //var user3Creds = new UserCredential { Login = "ClarkK", Password = "111zlt777" };
                //var user4Creds = new UserCredential { Login = "DanE", Password = "zxc333vbn" };

                //user1Creds.User = user1;
                //user2Creds.UserId = user2.Id;
                //user3.UserCredential = user3Creds; 
                //user4.UserCredential = user4Creds;

                //// Не добавляем user1Creds в БД
                //db.UserCredentials.AddRange(user2Creds, user3Creds, user4Creds);

                //db.SaveChanges();


                //var company1 = new Company { Name = "SF" };
                //var company2 = new Company { Name = "VK" };

                //var company3 = new Company { Name = "FB" };
                //db.Companies.Add(company3);
                //db.SaveChanges();

                //var user1 = new User { Name = "Arthur", Role = "Admin" };
                //var user2 = new User { Name = "Bob", Role = "Admin" };
                //var user3 = new User { Name = "Clark", Role = "User" };

                //user1.Company = company1;
                //company2.Users.Add(user2);
                //user3.CompanyId = company3.Id;

                //db.Companies.AddRange(company1, company2);
                //db.Users.AddRange(user1, user2, user3);

                //db.SaveChanges();


                // Many to many

                var topic1 = new Topic() { Name = "Раздел 1" };
                var topic2 = new Topic() { Name = "Раздел 2" };
                var topic3 = new Topic() { Name = "Раздел 3" };

                var user1 = new User() { Name = "Пользователь 1", Email = "gmail@gmail.com" };
                var user2 = new User() { Name = "Пользователь 2", Email = "gmail2@gmail.com" };
                var user3 = new User() { Name = "Пользователь 3", Email = "gmail3@gmail.com" };
                var user4 = new User() { Name = "Пользователь 4", Email = "gmail4@gmail.com" };

                topic1.Users.AddRange(new[] { user3, user4 });
                topic2.Users.AddRange(new[] { user1, user2 });

                user1.Topics.AddRange(new[] { topic1, topic3});

                db.Topics.AddRange(topic1, topic2, topic3);

                db.Users.AddRange(user1, user2, user3, user4);

                db.SaveChanges();
            }

        }
    }
}