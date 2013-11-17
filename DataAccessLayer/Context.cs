using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Proxies;
using System.Data;

namespace DataAccessLayer
{
    public class Context : IContext
    {
        string _connectionString;
        SqlConnection _connection;

        public Context(string connectionString)
        {
            _connectionString = connectionString;
        }

        
        public SqlConnection Connection
        {
            get
            {
                if (_connection == null)
                    _connection = new SqlConnection(_connectionString);
                return _connection;
            }
        }

        public void Dispose()
        {
            if (_connection == null)
                return;
            if (ConnectionState.Open.Equals(_connection.State))
                _connection.Close();
        }
    }
}
