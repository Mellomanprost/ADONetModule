using System.Data;
using Microsoft.Data.SqlClient;

namespace AdoNetLib
{
    public class DbExecutor
    {
        private MainConnector connector;

        public DbExecutor(MainConnector connector)
        {
            this.connector = connector;
        }

        // метод для выборки всех данных из указанной таблицы
        public DataTable SelectAll(string table)
        {
            var selectcommandtext = $"select * from {table}";
            var adapter = new SqlDataAdapter(selectcommandtext, connector.GetConnection());
            var ds = new DataSet();
            adapter.Fill(ds);
            return ds.Tables[0];
        }

        // метод, возвращающий в «основную» программу объект для чтения результата
        public SqlDataReader SelectAllCommandReader(string table)
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "select * from " + table,
                Connection = connector.GetConnection()
            };

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                return reader;
            }

            return null;

        }
    }
}
