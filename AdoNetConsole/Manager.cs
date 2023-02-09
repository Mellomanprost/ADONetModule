using System.Data;
using AdoNetLib;

namespace AdoNetConsole
{
    public class Manager
    {
        private MainConnector connector;
        private DbExecutor dbExecutor;
        private Table userTable;

        public Manager()
        {
            connector = new MainConnector();

            userTable = new Table();
            userTable.Name = "NetworkUser";
            userTable.ImportantField = "Login";
            userTable.Fields.Add("Id");
            userTable.Fields.Add("Login");
            userTable.Fields.Add("Name");
        }

        public int DeleteUserByLogin(string value)
        {
            return dbExecutor.DeleteByColumn(userTable.Name, userTable.ImportantField, value);
        }

        public void Connect()
        {
            var result = connector.ConnectAsync();

            if (result.Result)
            {
                Console.WriteLine("Подключено успешно!");

                dbExecutor = new DbExecutor(connector);
            }
            else
            {
                Console.WriteLine("Ошибка подключения!");
            }
        }

        public void Disconnect()
        {
            Console.WriteLine("Отключаем БД!");
            connector.DisconnectAsync();
        }

        public void ShowDataUsers()
        {
            Console.WriteLine("Получаем данные из таблицы " + userTable.Name);

            var data = dbExecutor.SelectAll(userTable.Name);

            Console.WriteLine("Количество строк в " + userTable.Name + ": " + data.Rows.Count);

            Console.WriteLine();
            foreach (DataColumn column in data.Columns)
            {
                Console.Write($"{column.ColumnName}\t");
            }

            Console.WriteLine();

            foreach (DataRow row in data.Rows)
            {

                var cells = row.ItemArray;
                foreach (var cell in cells)
                {
                    Console.Write($"{cell}\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void AddUser(string name, string login)
        {
            dbExecutor.ExecProcedureAdding(name, login);
        }

        public int UpdateUserByLogin(string value, string newvalue)
        {
            return dbExecutor.UpdateByColumn(userTable.Name, userTable.Fields[2], newvalue, userTable.Fields[1], value);
        }
    }
}
