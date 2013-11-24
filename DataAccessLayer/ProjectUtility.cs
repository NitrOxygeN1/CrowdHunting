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
    public static class ProjectUtility
    {
        public static IProject Get(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");
            
            SqlCommand command = new SqlCommand("select * from Project where id_project = @ProjectID");
            command.Parameters.Add(new SqlParameter("ProjectID", id));

            var adapter = new SqlDataAdapter(command);
            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            return new Project() {
                ProjectID = id,
                Name = dataSet.Tables[0].Rows[0]["name"].ToString(),
                Description = dataSet.Tables[0].Rows[0]["description"].ToString(),
                Date_start = DateTime.Parse(dataSet.Tables[0].Rows[0]["date_start"].ToString()),
                Date_end = DateTime.Parse(dataSet.Tables[0].Rows[0]["date_end"].ToString()),
                Status = dataSet.Tables[0].Rows[0]["status"].ToString(),
                GitHub_url = dataSet.Tables[0].Rows[0]["github_url"].ToString(),
                UserID = Guid.Parse(dataSet.Tables[0].Rows[0]["id_user"].ToString())
            };
        }

        public static void Add(IContext context, IProject project)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("insert into Project (name, description, date_start, date_end, status, github_url, id_user) values (@Name, @Description, @Date_start, @Date_end, @Status, @GitHub_url, @UserID)");
            command.Parameters.Add(new SqlParameter("Name", project.Name));
            command.Parameters.Add(new SqlParameter("Description", project.Description));
            command.Parameters.Add(new SqlParameter("Date_start", project.Date_start));
            command.Parameters.Add(new SqlParameter("Date_end", project.Date_end));
            command.Parameters.Add(new SqlParameter("Status", project.Status));
            command.Parameters.Add(new SqlParameter("GitHub_url", project.GitHub_url));
            command.Parameters.Add(new SqlParameter("UserID", project.UserID));

            command.ExecuteNonQuery();
        }

        public static void Update(IContext context, IProject project)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("update Project set name=@Name, description=@Description, date_start=@Date_start, date_end=@Date_end, status=@Status, github_url=@GitHub_url where id_project = @ProjectID");
            command.Parameters.Add(new SqlParameter("ProjectID", project.ProjectID));
            command.Parameters.Add(new SqlParameter("Name", project.Name));
            command.Parameters.Add(new SqlParameter("Description", project.Description));
            command.Parameters.Add(new SqlParameter("Date_start", project.Date_start));
            command.Parameters.Add(new SqlParameter("Date_end", project.Date_end));
            command.Parameters.Add(new SqlParameter("Status", project.Status));
            command.Parameters.Add(new SqlParameter("GitHub_url", project.GitHub_url));

            command.ExecuteNonQuery();
        }

        public static void Delete(IContext context, Guid id)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");

            SqlCommand command = new SqlCommand("delete from Project where id_project = @ProjectID");
            command.Parameters.Add(new SqlParameter("ProjectID", id));

            command.ExecuteNonQuery();
        }

        public static List<IProject> GetAll(IContext context)
        {
            Context ctx = context as Context;
            if (ctx == null)
                throw new Exception(typeof(Context).FullName + " expected.");
            
            SqlCommand command = new SqlCommand("select * from Project", ctx.Connection);
            var adapter = new SqlDataAdapter(command);
            var dataSet = new DataSet();

            adapter.Fill(dataSet);
            var dataTable = dataSet.Tables[0];

            List<IProject> projects = new List<IProject>();

            foreach (DataRow row in dataTable.Rows)
            {
                projects.Add(
                    new Project 
                    {
                        ProjectID = Guid.Parse(row["id_project"].ToString()),
                        Name = row["name"].ToString(),
                        Description = row["description"].ToString(),
                        Status = row["status"].ToString(),
                        UserID = Guid.Parse(row["id_user"].ToString()),
                        GitHub_url = row["github_url"].ToString(),
                        Date_start = DateTime.Parse(row["date_start"].ToString()),
                        Date_end = DateTime.Parse(row["date_end"].ToString())
                    }
                );
            }

            return projects;
        }
    }
}
