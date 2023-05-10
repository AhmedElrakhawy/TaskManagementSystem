using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class ViewTask : System.Web.UI.Page
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

                TimeSpan taskdate = (DateTime.Now - task.task_StartDate).Value;
                SelectedEmployee.DataSource = EmployeeManagerobj.GetEmployeesIds();
                SelectedEmployee.DataBind();
                TaskProject.Text = task.task_Project_Id.ToString();
                TaskProject.ReadOnly = true;

                if (taskdate.Hours < 3)
                {
                    TaskName.Text = task.task_Name;
                    TaskDescription.Text = task.task_Description;
                    SelectedEmployee.SelectedValue = task.task_Employee_Id.ToString();
                    
                    TaskStatus.SelectedValue = task.task_Status.ToString();
                }
                else
                {
                    TaskName.Text = task.task_Name;
                    TaskName.ReadOnly = true;
                    TaskDescription.Text = task.task_Description;
                    SelectedEmployee.SelectedValue = task.task_Employee_Id.ToString();
                    TaskStatus.SelectedValue = task.task_Status.ToString();
                }

            }


        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            Taskobj taskobj = new Taskobj();
            taskobj.task_Id = (int)Session["viewRow"];
            taskobj.task_Name = TaskName.Text;
            taskobj.task_Description = TaskDescription.Text;
            taskobj.task_Employee_Id = Int32.Parse(SelectedEmployee.SelectedValue);
            taskobj.task_Project_Id = Int32.Parse(TaskProject.Text);
            taskobj.task_Status = Int32.Parse(TaskStatus.SelectedValue);
            taskobj.task_StartDate = DateTime.Now;

            TaskManagerobj.ForwardATask(taskobj);

            Response.Redirect("TasksTable.aspx");
        }
    }
}