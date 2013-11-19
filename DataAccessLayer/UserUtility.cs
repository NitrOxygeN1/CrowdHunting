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
    public static class UserUtility
    {
        public static IUser Get(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("select * from User where id_user = @UserID");
            command.Parameters.Add(new SqlParameter("UserID", id));

            var adapter = new SqlDataAdapter(command);
            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            return new User()
            {
                UserID = id,
                Name = dataSet.Tables[0].Rows[0]["name"].ToString(),
                Surname = dataSet.Tables[0].Rows[0]["surname"].ToString(),
                GitHub_login = dataSet.Tables[0].Rows[0]["github_login"].ToString(),
                Password = dataSet.Tables[0].Rows[0]["password"].ToString(),
                Disabled = Int32.Parse(dataSet.Tables[0].Rows[0]["disabled"].ToString())
            };
        }

        public static void Add(IContext context, IUser user)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("insert into User (name, surname, github_login, password, disabled) values (@Name, @Surname, @GitHub_login, @Password, @Disabled)");
            command.Parameters.Add(new SqlParameter("Name", user.Name));
            command.Parameters.Add(new SqlParameter("Surname", user.Surname));
            command.Parameters.Add(new SqlParameter("GitHub_login", user.GitHub_login));
            command.Parameters.Add(new SqlParameter("Password", user.Password));
            command.Parameters.Add(new SqlParameter("Disabled", user.Disabled));

            command.ExecuteNonQuery();
        }

        public static void Update(IContext context, IUser user)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("update User set name=@Name, surname=@Surname, github_login=@GitHub_login, password=@Password, disabled=@Disabled where id_user = @UserID");
            command.Parameters.Add(new SqlParameter("UserID", user.UserID));
            command.Parameters.Add(new SqlParameter("Name", user.Name));
            command.Parameters.Add(new SqlParameter("Surname", user.Surname));
            command.Parameters.Add(new SqlParameter("GitHub_login", user.GitHub_login));
            command.Parameters.Add(new SqlParameter("Password", user.Password));
            command.Parameters.Add(new SqlParameter("Disabled", user.Disabled));

            command.ExecuteNonQuery();
        }

        public static void Delete(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("delete from User where id_user = @UserID");
            command.Parameters.Add(new SqlParameter("UserID", id));

            command.ExecuteNonQuery();
        }

        public static IUser GetByLogin(Context context, string login)
        {
            throw new NotImplementedException();
        }

        public static bool AuthorizedByRole(Guid userId, Guid resourceId)
        {
            bool result = false;
            using(Context ctx = new Context(""))
            {
                SqlCommand command = new SqlCommand("isAuthorizedByRole", ctx.Connection);
                command.Parameters.Add(new SqlParameter("UserID", userId));
                command.Parameters.Add(new SqlParameter("ResourceID", resourceId));
                command.Parameters.Add(new SqlParameter("Result", SqlDbType.Bit, 32, ParameterDirection.Output,
                    false, 0, 0, "", DataRowVersion.Default, result));
                command.CommandType = CommandType.StoredProcedure;                

                command.ExecuteNonQuery();
                return (bool)command.Parameters["Result"].Value;
            }
        }

        public static bool AuthorizedByInheritanceChain(Guid userId, Guid resourceId)
        {
            return true;
        }
    }
}
