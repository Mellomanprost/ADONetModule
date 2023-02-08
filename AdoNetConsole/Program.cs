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

                result = connector.ConnectAsync();

                Console.WriteLine();
                Console.WriteLine("Чтение данных взятых из БД с помощью SelectAll:");

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
                Console.WriteLine("Чтение с помощью метода SelectAllCommandReader:");

                if (result.Result)
                {
                    var reader = db.SelectAllCommandReader(tablename);

                    if (reader != null)
                    {
                        var columnList = new List<string>();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            var name = reader.GetName(i);
                            columnList.Add(name);
                        }

                        for (int i = 0; i < columnList.Count; i++)
                        {
                            Console.Write($"{columnList[i]}\t");
                        }
                        Console.WriteLine();

                        while (reader.Read())
                        {
                            for (int i = 0; i < columnList.Count; i++)
                            {
                                var value = reader[columnList[i]];
                                Console.Write($"{value}\t");
                            }

                            Console.WriteLine();
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Ошибка подключения!");
            }

        }
    }
}