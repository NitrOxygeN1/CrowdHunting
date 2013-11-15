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
    public static class UserSkillUtility
    {
        public static IUserSkill Get(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("select * from User_Skill where id_user_skill = @UserSkillID");
            command.Parameters.Add(new SqlParameter("UserSkillID", id));

            var adapter = new SqlDataAdapter(command);
            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            return new UserSkill()
            {
                UserSkillID = id,
                SkillID = Guid.Parse(dataSet.Tables[0].Rows[0]["id_skill"].ToString()),
                UserID = Guid.Parse(dataSet.Tables[0].Rows[0]["id_user"].ToString()),
                Level = Int32.Parse(dataSet.Tables[0].Rows[0]["level"].ToString())
            };
        }

        public static void Add(IContext context, IUserSkill user_skill)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("insert into User_Skill (id_skill, id_user, level) values (@SkillID, @UserID, @Level)");
            command.Parameters.Add(new SqlParameter("SkillID", user_skill.SkillID));
            command.Parameters.Add(new SqlParameter("UserID", user_skill.UserID));
            command.Parameters.Add(new SqlParameter("Level", user_skill.Level));

            command.ExecuteNonQuery();
        }

        public static void Update(IContext context, IUserSkill user_skill)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("update User_Skill set id_skill=@SkillID, id_user=@UserID, level=@Level where id_user_skill = @UserSkillID");
            command.Parameters.Add(new SqlParameter("UserSkillID", user_skill.UserSkillID));
            command.Parameters.Add(new SqlParameter("SkillID", user_skill.SkillID));
            command.Parameters.Add(new SqlParameter("UserID", user_skill.UserID));
            command.Parameters.Add(new SqlParameter("Level", user_skill.Level));

            command.ExecuteNonQuery();
        }

        public static void Delete(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("delete from User_Skill where id_user_skill = @UserSkillID");
            command.Parameters.Add(new SqlParameter("UserSkillID", id));

            command.ExecuteNonQuery();
        }
    }
}
