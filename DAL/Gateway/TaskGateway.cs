using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Generic;
using DAL;
using System.Linq;
using DAL.MappingClasses;
using DAL.DAO;

/// <summary>
/// Gateway of task with DB
/// </summary>
public class TaskGateway
{
    public bool InsertTask(Taskobj taskObject)
    {
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var task = TaskMapping.TaskObjToTaskDb(taskObject);
                context.Tasks.Add(task);
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public List<Taskobj> GetAllTasksOfAUser(int userId)
    {
        List<Taskobj> taskListObject = new List<Taskobj>();
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var employeeId = context.tbUsers.Find(userId).user_employee_Id;
                if (employeeId != null)
                {

                    var tasks = context.Tasks.Where(x => x.task_Employee_Id == employeeId).ToList();
                    foreach (var task in tasks)
                    {
                        taskListObject.Add(TaskMapping.TaskDbToTaskobj(task));
                    }
                }

            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
        return taskListObject;
    }

    public List<Taskobj> SelectAllTasksOfTheProject(int projectId)
    {
        List<Taskobj> taskListObject = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var tasks = context.Tasks.Where(x => x.task_Project_Id == projectId).ToList();
                foreach (var task in tasks)
                {
                    taskListObject.Add(TaskMapping.TaskDbToTaskobj(task));
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return taskListObject;
    }

    public bool UpdateTaskStatus(Taskobj taskObject)
    {
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var task = context.Tasks.Find(taskObject.task_Id);
                task.task_Status = taskObject.task_Status;
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<Taskobj> SelectAllOpenTaskOfTheProject(int projectId, int? employeeId)
    {
        List<Taskobj> taskListObject = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var tasks = context.Tasks.Where(x => x.task_Project_Id == projectId && x.task_Status == 1).ToList();
                if (employeeId != null)
                {
                    tasks = tasks.Where(x => x.task_Employee_Id == employeeId).ToList();
                }
                foreach (var task in tasks)
                {
                    taskListObject.Add(TaskMapping.TaskDbToTaskobj(task));
                }
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
        return taskListObject;
    }
    public List<Taskobj> SelectAllClosedTasks()
    {
        List<Taskobj> taskListObject = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var tasks = context.Tasks.Where(x => x.task_Status == 0).ToList();

                foreach (var task in tasks)
                {
                    taskListObject.Add(TaskMapping.TaskDbToTaskobj(task));
                }
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
        return taskListObject;
    }
    public List<Taskobj> SelectAllOpenTasks()
    {
        List<Taskobj> taskListObject = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var tasks = context.Tasks.Where(x => x.task_Status == 1).ToList();

                foreach (var task in tasks)
                {
                    taskListObject.Add(TaskMapping.TaskDbToTaskobj(task));
                }
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
        return taskListObject;
    }
    public List<Task> SearchTask(int? Status, string AssignedTo)
    {
        List<Task> tasks = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                tasks = context.Tasks.Where(x => x.task_Status == Status).ToList();
                if (!String.IsNullOrEmpty(AssignedTo))
                {
                    var employeeId = context.Employees.Where(x => x.employee_Name == AssignedTo).FirstOrDefault().employee_Id;
                    tasks = tasks.Where(x => x.task_Employee_Id == employeeId).ToList();
                }

            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
        return tasks;
    }

    public bool UpdateTask(Taskobj taskObj)
    {
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var task = TaskMapping.TaskObjToTaskDb(taskObj);
                context.Entry(task).State = EntityState.Modified;
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public Taskobj SelectTask(int taskId)
    {
        Taskobj taskObject = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var task = context.Tasks.Find(taskId);
                taskObject = TaskMapping.TaskDbToTaskobj(task);
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }

        return taskObject;
    }



    public List<Task> GetListOfAllTasks()
    {
        List<Task> taskListObject = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var tasks = context.Tasks.ToList();
                taskListObject = tasks;
                //foreach (var task in tasks)
                //{
                //    taskListObject.Add(TaskMapping.TaskDbToTaskobj(task));
                //}
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return taskListObject;
    }

    public List<Taskobj> GetAllOpenTasksOfAUser(int employeeId)
    {
        List<Taskobj> taskListObject = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var tasks = context.Tasks.Where(x => x.task_Employee_Id == employeeId && x.task_Status == 1).ToList();
                foreach (var task in tasks)
                {
                    taskListObject.Add(TaskMapping.TaskDbToTaskobj(task));
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return taskListObject;
    }

    public bool CloseTask(int taskId)
    {
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var taskdb = context.Tasks.Find(taskId);
                taskdb.task_Status = 0;
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool AddTaskToEmployee(Taskobj taskobj)
    {
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var task = TaskMapping.TaskObjToTaskDb(taskobj);
                context.Tasks.Add(task);
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }

    }
}
