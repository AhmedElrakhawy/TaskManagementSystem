using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MappingClasses
{
    public class TaskMapping
    {
        public static Task TaskObjToTaskDb(Taskobj taskobj)
        {
            return new Task
            {
               task_Id = taskobj.task_Id, 
               task_Employee_Id = taskobj.task_Employee_Id, 
               task_Description = taskobj.task_Description, 
               task_Project_Id = taskobj.task_Project_Id, 
               task_StartDate = taskobj.task_StartDate, 
               task_EndDate = taskobj.task_EndDate, 
               task_Name = taskobj.task_Name, 
               task_Status = taskobj.task_Status, 
            };
        }
        public static Taskobj TaskDbToTaskobj(Task task)
        {
            return new Taskobj
            {
                task_Id = task.task_Id,
                task_Employee_Id = task.task_Employee_Id,
                task_Description = task.task_Description ,
                task_Project_Id = task.task_Project_Id,
                task_StartDate = task.task_StartDate ,
                task_EndDate = task.task_EndDate,
                task_Name = task.task_Name,
                task_Status = task.task_Status,
                
            };
        }
    }
}
