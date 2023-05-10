using System;
using System.Data;
using System.Configuration;
using System.Web;
using DAL;
using System.Collections.Generic;

public class Projectobj
{
    public int project_Id { get; set; }
    public string project_Title { get; set; }
    public string project_Description { get; set; }
    public DateTime project_StartTime { get; set; }
    public int project_Status { get; set; }
    public  List<Task> Tasks { get; set; }
}
