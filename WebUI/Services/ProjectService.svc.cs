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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PrjectService" in code, svc and config file together.
    public class ProjectService : IProjectService
    {

        public ServiceAnswer<IProject> GetById(Guid project_id)
        {
            var result = new ServiceAnswer<IProject>();
            try
            {
                IProject project = ProjectContext.Get(project_id);
                if (project == null)
                {
                    result.CallResult = CallResult.NotFound;
                    result.ErrorText = "Can't found project by id";
                }
                else
                {
                    result.CallResult = CallResult.Ok;
                    result.Data = project;
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
