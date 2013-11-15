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
    public static class SkillUtility
    {
        public static ISkill Get(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("select * from Skill where id_skill = @SkillID");
            command.Parameters.Add(new SqlParameter("SkillID", id));

            var adapter = new SqlDataAdapter(command);
            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            return new Skill()
            {
                SkillID = id,
                Title = dataSet.Tables[0].Rows[0]["title"].ToString(),
            };
        }

        public static void Add(IContext context, ISkill skill)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("insert into Skill (title) values (@Title)");
            command.Parameters.Add(new SqlParameter("Title", skill.Title));

            command.ExecuteNonQuery();
        }

        public static void Update(IContext context, ISkill skill)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("update Skill set title=@Title where id_skill = @SkillID");
            command.Parameters.Add(new SqlParameter("SkillID", skill.SkillID));
            command.Parameters.Add(new SqlParameter("Title", skill.Title));

            command.ExecuteNonQuery();
        }

        public static void Delete(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("delete from Skill where id_skill = @SkillID");
            command.Parameters.Add(new SqlParameter("SkillID", id));

            command.ExecuteNonQuery();
        }
    }
}
