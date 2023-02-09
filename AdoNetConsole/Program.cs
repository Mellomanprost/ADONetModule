namespace AdoNetConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager();

            manager.Connect();

            manager.ShowDataUsers();

            // Удаление пользователя по логину
            //Console.WriteLine("Введите логин для удаления:");
            //var countDeletedRows = manager.DeleteUserByLogin(Console.ReadLine());
            //Console.WriteLine("Количество удаленных строк: " + countDeletedRows);

            //manager.ShowDataUsers();

            // Создание пользователя
            //Console.WriteLine("Введите логин для добавления:");
            //var login = Console.ReadLine();

            //Console.WriteLine("Введите имя для добавления:");
            //var name = Console.ReadLine();

            //manager.AddUser(login, name);

            // Обновление имени пользователя по логину
            Console.WriteLine("Введите логин для обновления:");
            var loginChck = Console.ReadLine();

            Console.WriteLine("Введите новое имя:");
            var nameUpd = Console.ReadLine();

            manager.UpdateUserByLogin(loginChck, nameUpd);

            manager.ShowDataUsers();

            manager.Disconnect();
        }
    }
}