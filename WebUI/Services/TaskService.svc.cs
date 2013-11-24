using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Proxies;
using BusinessLayer;

namespace WebUI.Services
{
    public class TaskService : ITaskService
    {
        public ServiceAnswer<ITask> Get(Guid task_id)
        {
            var result = new ServiceAnswer<ITask>();
            try
            {
                ITask task = TaskContext.Get(task_id);
                if (task == null)
                {
                    result.CallResult = CallResult.NotFound;
                    result.ErrorText = "Can't find task by id";
                }
                else
                {
                    result.CallResult = CallResult.Ok;
                    result.Data = task;
                }
            }
            catch (Exception ex)
            {
                result.CallResult = CallResult.ExceptionOccured;
                result.ErrorType = ex.GetType().FullName;
                result.ErrorText = ex.Message;
            }
            return result;
        }
    }
}
