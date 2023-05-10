using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logInButton_Click(object sender, EventArgs e)
        {
            string userType = null;
            try
            {
                UserManager userManagerObject = new UserManager();
                userType = userManagerObject.CheckUserIdAndPassword(Int32.Parse(UserId.Text), passwordTextBox.Text);
                Session["UserId"] = Int32.Parse(UserId.Text);
            }
            catch (SqlException sqlExceptionObj)
            {
                Label1.Text = sqlExceptionObj.Message;
            }
            catch (Exception exceptionObj)
            {
                Label1.Text = exceptionObj.Message;
            }


            switch (userType)
            {
                case "Admin":
                    Response.Redirect("TasksTable.aspx");
                    break;
                case "Normal":
                    Response.Redirect("NormalUserPage.aspx");
                    break;
                default:
                    Label1.Text = " Invalid Password! Please retype the Password";
                    break;
            }
        }
    }
}