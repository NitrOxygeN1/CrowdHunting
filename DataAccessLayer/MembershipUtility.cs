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
    public static class MembershipUtility
    {
        public static IMembership Get(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("select * from Membership where id_member = @MemberID");
            command.Parameters.Add(new SqlParameter("MemberID", id));

            var adapter = new SqlDataAdapter(command);
            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            return new Membership()
            {
                MemberID = id,
                UserID = Guid.Parse(dataSet.Tables[0].Rows[0]["id_user"].ToString()),
                ProjectID = Guid.Parse(dataSet.Tables[0].Rows[0]["id_project"].ToString()),
                RoleID = Guid.Parse(dataSet.Tables[0].Rows[0]["id_role"].ToString()),
                Active = Int32.Parse(dataSet.Tables[0].Rows[0]["active"].ToString())
            };
        }

        public static void Add(IContext context, IMembership member)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("insert into Membership (id_user, id_project, id_role, active) values (@UserID, @ProjectID, @RoleID, @Active)");
            command.Parameters.Add(new SqlParameter("UserID", member.UserID));
            command.Parameters.Add(new SqlParameter("ProjectID", member.ProjectID));
            command.Parameters.Add(new SqlParameter("RoleID", member.RoleID));
            command.Parameters.Add(new SqlParameter("Active", member.Active));

            command.ExecuteNonQuery();
        }

        public static void Update(IContext context, IMembership member)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("update Membership set id_user=@UserID, id_project=@ProjectID, id_role=@RoleID, active=@Active where id_member = @MemberID");
            command.Parameters.Add(new SqlParameter("MemberID", member.MemberID));
            command.Parameters.Add(new SqlParameter("UserID", member.UserID));
            command.Parameters.Add(new SqlParameter("ProjectID", member.ProjectID));
            command.Parameters.Add(new SqlParameter("RoleID", member.RoleID));
            command.Parameters.Add(new SqlParameter("Active", member.Active));

            command.ExecuteNonQuery();
        }

        public static void Delete(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("delete from Membership where where id_member = @MemberID");
            command.Parameters.Add(new SqlParameter("MemberID", id));

            command.ExecuteNonQuery();
        }
    }
}
