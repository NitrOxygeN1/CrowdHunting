using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proxies;
using DataAccessLayer;

namespace BusinessLayer
{
    public class ProjectContext
    {
        public static IProject Get(Guid project_id)
        {
            using (Context ctx = new Context(""))
            {
                return ProjectUtility.Get(ctx, project_id);
            }
        }

        public static List<IProject> GetAll()
        {
            using (Context ctx = new Context(""))
            {
                return ProjectUtility.GetAll(ctx);
            }
        }

        public static void Delete(Guid project_id)
        {
            if(project_id == null)
                return;
            using (Context ctx = new Context(""))
            {
                ProjectUtility.Delete(ctx, project_id);
            }
        }

        public static void Update(IProject project)
        {
            if (project == null)
                return;
            using (Context ctx = new Context(""))
            {
                ProjectUtility.Update(ctx, project);
            }
        }
    }
}
