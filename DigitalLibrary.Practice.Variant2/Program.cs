namespace DigitalLibrary.Practice.Variant2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userRepos = new UserRepository();
            var bookRepos = new BookRepository();

            Console.WriteLine("Добро пожаловать в систему управления электронной библиотекой!");

            using (var db = new AppContext())
            {
                // Заполнение пользователей
                userRepos.AddUser("Leha", "leha@mail.ru");
                userRepos.AddUser("Dima", "dima@mail.ru");
                userRepos.AddUser("Sergey", "sergey@mail.ru");
                userRepos.AddUser("Maxim", "maxim@mail.ru");
                userRepos.AddUser("Vadim", "vadim@mail.ru");

                // Заполнение книг
                bookRepos.AddBook("Стоик", 1947, "Теодор Драйзер", "Роман");
                bookRepos.AddBook("Шерлок Холмс", 1892, "Артур-Конан Дойл", "Детектив");
                bookRepos.AddBook("Думай медленно... Решай быстро", 2011, "Даниэль Канеман", "Научпоп");
                bookRepos.AddBook("Задача трех тел", 2006, "Лю Цысинь", "Роман");
                bookRepos.AddBook("Тревожные люди", 2019, "Фредрик Бакман", "Роман");
                bookRepos.AddBook("Вторая жизнь Уве", 2012, "Фредрик Бакман", "Роман");

            }

        }
    }
}