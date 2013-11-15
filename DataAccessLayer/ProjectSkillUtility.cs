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
    public static class ProjectSkillUtility
    {
        public static IProjectSkill Get(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("select * from Project_Skill where id_project_skill = @ProjectSkillID");
            command.Parameters.Add(new SqlParameter("ProjectSkillID", id));

            var adapter = new SqlDataAdapter(command);
            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            return new ProjectSkill()
            {
                ProjectSkillID = id,
                SkillID = Guid.Parse(dataSet.Tables[0].Rows[0]["id_skill"].ToString()),
                ProjectID = Guid.Parse(dataSet.Tables[0].Rows[0]["id_project"].ToString()),
                Level = Int32.Parse(dataSet.Tables[0].Rows[0]["level"].ToString())
            };
        }

        public static void Add(IContext context, IProjectSkill project_skill)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("insert into Project_Skill (id_skill, id_project, level) values (@SkillID, @ProjectID, @Level)");
            command.Parameters.Add(new SqlParameter("SkillID", project_skill.SkillID));
            command.Parameters.Add(new SqlParameter("ProjectID", project_skill.ProjectID));
            command.Parameters.Add(new SqlParameter("Level", project_skill.Level));

            command.ExecuteNonQuery();
        }

        public static void Update(IContext context, IProjectSkill project_skill)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("update Project_Skill set id_skill=@SkillID, id_project=@ProjectID, level=@Level where id_project_skill = @ProjectSkillID");
            command.Parameters.Add(new SqlParameter("ProjectSkillID", project_skill.ProjectSkillID));
            command.Parameters.Add(new SqlParameter("SkillID", project_skill.SkillID));
            command.Parameters.Add(new SqlParameter("ProjectID", project_skill.ProjectID));
            command.Parameters.Add(new SqlParameter("Level", project_skill.Level));

            command.ExecuteNonQuery();
        }

        public static void Delete(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("delete from Project_Skill where id_project_skill = @ProjectSkillID");
            command.Parameters.Add(new SqlParameter("ProjectSkillID", id));

            command.ExecuteNonQuery();
        }
    }
}
