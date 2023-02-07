using System.Data;
using AdoNetLib;

namespace AdoNetConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var connector = new MainConnector();

            var result = connector.ConnectAsync();

            var data = new DataTable();

            if (result.Result)
            {
                Console.WriteLine("Подключено успешно!");
                var db = new DbExecutor(connector);
                var tablename = "NetworkUser";
                Console.WriteLine("Получаем данные из таблицы " + tablename);
                data = db.SelectAll(tablename);
                Console.WriteLine("Количество строк в " + tablename + ": " + data.Rows.Count);
                Console.WriteLine("Отключаем БД!");
                connector.DisconnectAsync();
            }
            else
            {
                Console.WriteLine("Ошибка подключения!");
            }


        }
    }
}