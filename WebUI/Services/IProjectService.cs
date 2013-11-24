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
    [ServiceContract]
    public interface IProjectService
    {
        [OperationContract]
        ServiceAnswer<IProject> GetById(Guid project_id);
    }
}
