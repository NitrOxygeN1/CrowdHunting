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
    public static class TaskSkillUtility
    {
        public static ITaskSkill Get(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("select * from Task_Skill where id_task_skill = @TaskSkillID");
            command.Parameters.Add(new SqlParameter("TaskSkillID", id));

            var adapter = new SqlDataAdapter(command);
            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            return new TaskSkill()
            {
                TaskSkillID = id,
                SkillID = Guid.Parse(dataSet.Tables[0].Rows[0]["id_skill"].ToString()),
                TaskID = Guid.Parse(dataSet.Tables[0].Rows[0]["id_task"].ToString()),
                Level = Int32.Parse(dataSet.Tables[0].Rows[0]["level"].ToString())
            };
        }

        public static void Add(IContext context, ITaskSkill task_skill)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("insert into Task_Skill (id_skill, id_task, level) values (@SkillID, @TaskID, @Level)");
            command.Parameters.Add(new SqlParameter("SkillID", task_skill.SkillID));
            command.Parameters.Add(new SqlParameter("TaskID", task_skill.TaskID));
            command.Parameters.Add(new SqlParameter("Level", task_skill.Level));

            command.ExecuteNonQuery();
        }

        public static void Update(IContext context, ITaskSkill task_skill)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("update Task_Skill set id_skill=@SkillID, id_task=@TaskID, level=@Level where id_task_skill = @TaskSkillID");
            command.Parameters.Add(new SqlParameter("TaskSkillID", task_skill.TaskSkillID));
            command.Parameters.Add(new SqlParameter("SkillID", task_skill.SkillID));
            command.Parameters.Add(new SqlParameter("TaskID", task_skill.TaskID));
            command.Parameters.Add(new SqlParameter("Level", task_skill.Level));

            command.ExecuteNonQuery();
        }

        public static void Delete(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("delete from Task_Skill where id_task_skill = @TaskSkillID");
            command.Parameters.Add(new SqlParameter("TaskSkillID", id));

            command.ExecuteNonQuery();
        }
    }
}
