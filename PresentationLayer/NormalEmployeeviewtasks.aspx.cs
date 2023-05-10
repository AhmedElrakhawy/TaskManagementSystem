using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class NormalEmployeeviewtasks : System.Web.UI.Page
    {
            TaskManager TaskManagerobj = new TaskManager();
            EmployeeManager EmployeeManagerobj = new EmployeeManager();
            ProjectManager ProjectManagerobj = new ProjectManager();
            protected void Page_Load(object sender, EventArgs e)
            {
                int row = 0;
                if (!IsPostBack)
                {
                    row = (int)Session["viewRow"];

                    var task = TaskManagerobj.SelectTask(row);
                TaskName.Text = task.task_Name;
                TaskName.ReadOnly = true;
                TaskStatus.SelectedValue = task.task_Status.ToString();
                }
            }

            protected void SaveBtn_Click(object sender, EventArgs e)
            {
                Taskobj taskobj = new Taskobj();
                taskobj.task_Id = (int)Session["viewRow"];
                taskobj.task_Name = TaskName.Text;
                taskobj.task_Status = Int32.Parse(TaskStatus.SelectedValue);

                TaskManagerobj.UpdateTaskStatus(taskobj);

                Response.Redirect("UserTasksPage.aspx");
            }
        }
}