using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proxies;
using DataAccessLayer;

namespace BusinessLayer
{
    public class TaskContext
    {
        public static ITask Get(Guid task_id)
        {
            if(task_id == null)
                return null;
            using (Context ctx = new Context(""))
            {
                return TaskUtility.Get(ctx, task_id);
            }
        }

        public static void Add(ITask task)
        {
        }

        public static void Update(ITask task)
        {
        }

        public static void Delete(Guid task_id)
        {
        }

        public static void Resolve(Guid task_id)
        {
        }

        public static List<ITask> GetAllProjectTask(Guid project_id)
        {
            List<ITask> projectTasks = null;
            if (project_id == null)
                return projectTasks;
            using (Context ctx = new Context(""))
            {
                projectTasks = TaskUtility.GetAllProjectTasks(ctx, project_id);
            }
            return projectTasks;
        }

        public static List<ITask> GetAllUserTask(Guid user_id)
        {
            return null;
        }
    }
}
