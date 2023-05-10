using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class OldTasksPage : System.Web.UI.Page
    {
        TaskManager TaskManagerobj = new TaskManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var userId = (int)Session["UserId"];
                var tasks = TaskManagerobj.getAllUserTasks(userId);
                GridView1.DataSource = tasks;
                GridView1.DataBind(); 
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int row = (int)this.GridView1.SelectedDataKey.Value;
            Session["viewRow"] = row;
            Response.Redirect("NormalEmployeeviewtasks.aspx");
        }
    }
}