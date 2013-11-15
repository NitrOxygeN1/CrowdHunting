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
    public static class TaskUtility
    {
        public static ITask Get(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("select * from Task where id_task = @TaskID");
            command.Parameters.Add(new SqlParameter("TaskID", id));

            var adapter = new SqlDataAdapter(command);
            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            return new Task()
            {
                TaskID = id,
                Task_title = dataSet.Tables[0].Rows[0]["task_title"].ToString(),
                Task_description = dataSet.Tables[0].Rows[0]["task_description"].ToString(),
                GitHub_id = Int32.Parse(dataSet.Tables[0].Rows[0]["github_id"].ToString()),
                Karma = Int32.Parse(dataSet.Tables[0].Rows[0]["karma"].ToString())
            };
        }

        public static void Add(IContext context, ITask task)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("insert into Task (task_title, task_description, github_id, karma) values (@Task_title, @Task_description, @GitHub_id, @Karma)");
            command.Parameters.Add(new SqlParameter("Task_title", task.Task_title));
            command.Parameters.Add(new SqlParameter("Task_description", task.Task_description));
            command.Parameters.Add(new SqlParameter("GitHub_id", task.GitHub_id));
            command.Parameters.Add(new SqlParameter("Karma",task.Karma));

            command.ExecuteNonQuery();
        }

        public static void Update(IContext context, ITask task)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("update Task set task_title=@Task_title, task_description=@Task_description, github_id=@GitHub_id, karma=@Karma where id_task = @TaskID");
            command.Parameters.Add(new SqlParameter("TaskID", task.TaskID));
            command.Parameters.Add(new SqlParameter("Task_title", task.Task_title));
            command.Parameters.Add(new SqlParameter("Task_description", task.Task_description));
            command.Parameters.Add(new SqlParameter("GitHub_id", task.GitHub_id));
            command.Parameters.Add(new SqlParameter("Karma", task.Karma));

            command.ExecuteNonQuery();
        }

        public static void Delete(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("delete from Task where id_task = @TaskID");
            command.Parameters.Add(new SqlParameter("TaskID", id));

            command.ExecuteNonQuery();
        }
    }
}
