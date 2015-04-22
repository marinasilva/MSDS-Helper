using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MSDSHelper.Model;

namespace MSDSHelper.DAL
{
    public class ContextFactory 
    {
        private static SqlConnection _connection;
        static readonly object Sentinel = new object();

        public static SqlConnection Instancia()
        {
            lock (Sentinel)
            {
                string connectionString = @"Server=HNT-127\SQLEXPRESS; Database=MSDSHelper; User=sql; Password=se4rf";
                if (_connection != null && _connection.ConnectionString != String.Empty) return _connection;
                _connection = new SqlConnection(connectionString);
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();return _connection;
            }
        }
    }
}
