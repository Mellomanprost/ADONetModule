﻿namespace AdoNetConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager();

            manager.Connect();

            manager.ShowDataUsers();

            Console.WriteLine("Введите логин для удаления:");

            var countDeletedRows = manager.DeleteUserByLogin(Console.ReadLine());

            Console.WriteLine("Количество удаленных строк: " + countDeletedRows);

            manager.ShowDataUsers();

            manager.Disconnect();

            Console.WriteLine("Введите логин для добавления:");
            var login = Console.ReadLine();

            Console.WriteLine("Введите имя для добавления:");
            var name = Console.ReadLine();

            manager.AddUser(login, name);
        }
    }
}