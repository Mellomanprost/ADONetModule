﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
