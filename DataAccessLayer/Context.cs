using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Proxies;

namespace DataAccessLayer
{
    public class Context : IContext
    {
        string _connectionString;

        public Context(string connectionString)
        {
            _connectionString = connectionString;
        }

        SqlConnection _connection;
        public SqlConnection Connection
        {
            get
            {
                if (_connection == null)
                    _connection = new SqlConnection(_connectionString);
                return _connection;
            }
        }
    }
}
