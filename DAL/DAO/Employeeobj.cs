using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using DAL;
/// <summary>
/// This class is responsible for Employee related data
/// </summary>
public class Employeeobj
{
    public int employee_Id { get; set; }
    public string employee_Name { get; set; }
    public string employee_Address { get; set; }
    public string employee_PhoneNumber { get; set; }
    public string employee_Email { get; set; }
    public string employee_JoinDate { get; set; }
    public string employee_DateOfBirth { get; set; }
    public string employee_AuthenticationMode { get; set; }

    public virtual List<Task> Tasks { get; set; }
    public  Userobj user { get; set; }

}
