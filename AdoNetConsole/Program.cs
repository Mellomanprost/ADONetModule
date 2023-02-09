namespace AdoNetConsole
{
    public class Program
    {
        private static Manager manager;

        public enum Commands
        {
            stop,
            add,
            delete,
            update,
            show
        }

        static void Main(string[] args)
        {
            manager = new Manager();

            manager.Connect();

            Console.WriteLine("Список команд для работы консоли:");
            Console.WriteLine(Commands.stop + ": прекращение работы");
            Console.WriteLine(Commands.add + ": добавление данных");
            Console.WriteLine(Commands.delete + ": удаление данных");
            Console.WriteLine(Commands.update + ": обновление данных");
            Console.WriteLine(Commands.show + ": просмотр данных");
            
            string command;

            do
            {
                Console.WriteLine("Напишите команду:");
                command = Console.ReadLine();
                Console.WriteLine();


                switch (command)
                {
                    case nameof(Commands.add):
                    {
                        Add();
                        break;
                    }

                    case nameof(Commands.delete):
                    {
                        Delete();
                        break;
                    }

                    case nameof(Commands.update):
                    {
                        Update();
                        break;
                    }

                    case nameof(Commands.show):
                    {
                        manager.ShowDataUsers();
                        break;
                    }
                }
            } while (command != nameof(Commands.stop));

            manager.Disconnect();
        }

        /// <summary>
        /// Метод для создания пользователя
        /// </summary>
        public static void Add()
        {
            Console.WriteLine("Введите логин для добавления:");
            var login = Console.ReadLine();

            Console.WriteLine("Введите имя для добавления:");
            var name = Console.ReadLine();

            manager.AddUser(login, name);

            manager.ShowDataUsers();
        }

        /// <summary>
        /// Метод для удаления пользователя по логину
        /// </summary>
        public static void Delete()
        {
            Console.WriteLine("Введите логин для удаления:");
            var countDeletedRows = manager.DeleteUserByLogin(Console.ReadLine());

            Console.WriteLine("Количество удаленных строк: " + countDeletedRows);

            manager.ShowDataUsers();
        }

        /// <summary>
        /// Метод для обновления имени пользователя по логину
        /// </summary>
        public static void Update()
        {
            Console.WriteLine("Введите логин для обновления:");
            var login = Console.ReadLine();

            Console.WriteLine("Введите новое имя:");
            var name = Console.ReadLine();

            var count = manager.UpdateUserByLogin(login, name);
            Console.WriteLine("Строк обновлено" + count);
            manager.ShowDataUsers();
        }
    }
}