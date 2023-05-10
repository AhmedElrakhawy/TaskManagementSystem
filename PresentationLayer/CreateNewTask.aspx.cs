using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{


    public partial class CreateNewTask : System.Web.UI.Page
    {
        private ProjectManager ProjectManagerobj = new ProjectManager();
        private EmployeeManager EmployeeManagerobj = new EmployeeManager();
        private TaskManager TaskManagerobj = new TaskManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<int> ProjectsIds = new List<int>();
                var projects = ProjectManagerobj.GetAllOpenProjects();
                foreach (var proj in projects)
                {
                    ProjectsIds.Add(proj.project_Id);
                }
                SelectedProject.DataSource = ProjectsIds;
                SelectedProject.DataBind();


                SelectedEmployee.DataSource = EmployeeManagerobj.GetEmployeesIds();
                SelectedEmployee.DataBind();

            }
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            var task = new Taskobj();
            task.task_Name = TaskName.Text;
            task.task_Description = TaskDescription.Text;
            task.task_StartDate = DateTime.Now;
            task.task_EndDate = DateTime.Now.AddDays(7);
            task.task_Project_Id = Int32.Parse(SelectedProject.SelectedValue);
            task.task_Employee_Id = Int32.Parse(SelectedEmployee.SelectedValue);
            task.task_Status = Int32.Parse(TaskStatus.SelectedValue);
            TaskManagerobj.SaveTask(task);
            Response.Redirect("TasksTable.aspx");
        }
    }
}