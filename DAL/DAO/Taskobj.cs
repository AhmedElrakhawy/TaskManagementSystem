using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class Taskobj
    {
        public int task_Id { get; set; }
        public string task_Name { get; set; }
        public string task_Description { get; set; }
        public DateTime? task_StartDate { get; set; }
        public DateTime? task_EndDate { get; set; }
        public int? task_Employee_Id { get; set; }
        public int? task_Project_Id { get; set; }
        public int? task_Status { get; set; }
    }
}
