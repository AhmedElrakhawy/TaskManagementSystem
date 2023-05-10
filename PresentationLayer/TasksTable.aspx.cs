using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class TasksTable : System.Web.UI.Page
    {
        private TaskManager taskManagerobj = new TaskManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = taskManagerobj.GetListOfAllTasks();
                GridView1.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedval = Int32.Parse(DropDownList1.SelectedValue);
            GridView1.DataSource = taskManagerobj.SearchTask(selectedval,TextBox1.Text);
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var selectedval = Int32.Parse(DropDownList1.SelectedValue);
            GridView1.DataSource = taskManagerobj.SearchTask(selectedval, TextBox1.Text);
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateNewTask.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int row = (int)this.GridView1.SelectedDataKey.Value;
            Session["viewRow"] = row;
            Response.Redirect("ViewTask.aspx");
        }
    }
}