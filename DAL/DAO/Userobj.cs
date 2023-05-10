using System;
using System.Data;
using System.Configuration;
using System.Web;
using DAL;

public class Userobj
{
    public int user_Id { get; set; }
    public DateTime user_CreatedDate { get; set; }
    public string user_Password { get; set; }
    public int user_employee_Id { get; set; }
    public string user_AuthenticationMode { get; set; }

    public Employee Employee { get; set; }
}
