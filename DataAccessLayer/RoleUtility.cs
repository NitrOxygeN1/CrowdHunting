using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proxies;
using DataAccessLayer.Entities;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public static class RoleUtility
    {
        public static IRole Get(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("select * from Role where id_role = @RoleID");
            command.Parameters.Add(new SqlParameter("RoleID", id));

            var adapter = new SqlDataAdapter(command);
            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            return new Role()
            {
                RoleID = id,
                Title = dataSet.Tables[0].Rows[0]["title"].ToString(),
            };
        }

        public static void Add(IContext context, IRole role)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("insert into Role (title) values (@Title)");
            command.Parameters.Add(new SqlParameter("Title", role.Title));

            command.ExecuteNonQuery();
        }

        public static void Update(IContext context, IRole role)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("update Role set title=@Title where id_role = @RoleID");
            command.Parameters.Add(new SqlParameter("RoleID", role.RoleID));
            command.Parameters.Add(new SqlParameter("Title", role.Title));

            command.ExecuteNonQuery();
        }

        public static void Delete(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("delete from Role where id_role = @RoleID");
            command.Parameters.Add(new SqlParameter("RoleID", id));

            command.ExecuteNonQuery();
        }
    }
}
