using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class NormalUserPage : System.Web.UI.Page
    {
        private TaskManager TaskManagerobj = new TaskManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var userId = (int)Session["UserId"];
                var UserTasks = TaskManagerobj.getAllUserTasks(userId);
                int oldtasks = 0; 
                int newtasks = 0;
                if (UserTasks !=null)
                {
                    foreach (var task in UserTasks)
                    {
                        var time = (DateTime.Now - task.task_StartDate).Value;
                        if (time.Days < 3)
                        {
                            newtasks++;
                        }
                        else
                        {
                            oldtasks++;
                        }
                    }
                }
                

                NewTasksCounter.Text = newtasks.ToString();

                OldTasksCounter.Text = oldtasks.ToString();
            }
        }

        protected void ViewALl_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserTasksPage");
        }
    }
}