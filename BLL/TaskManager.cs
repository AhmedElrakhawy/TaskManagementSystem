using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Data.SqlClient;
using DAL.DAO;
using DAL;


public class TaskManager
{
    private TaskGateway taskGatewayObject = new TaskGateway();
    public string SaveTask(Taskobj taskObj)
    {
        bool isSaved = false;
        try
        {
            isSaved = taskGatewayObject.InsertTask(taskObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        if (isSaved)
        {
            return "Task information saved";
        }
        else
        {
            return "Task information is not saved";
        }
    }

    public List<Taskobj> getAllUserTasks(int userId)
    {

        List<Taskobj> userAllTasks = null;
        try
        {
            TaskGateway taskGatewayObj = new TaskGateway();
            userAllTasks = taskGatewayObj.GetAllTasksOfAUser(userId);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return userAllTasks;
    }

    public string UpdateTask(Taskobj taskObject)
    {
        bool isSaved = false;
        try
        {
            isSaved = taskGatewayObject.UpdateTask(taskObject);
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }

        if (isSaved)
        {
            return "Task has been updated.";
        }
        else
        {
            return "Task is not updated";
        }
    }

    public string UpdateTaskStatus(Taskobj taskObject)
    {
        bool isSaved = false;
        try
        {
            isSaved = taskGatewayObject.UpdateTaskStatus(taskObject);
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }

        if (isSaved)
        {
            return "Task has been updated.";
        }
        else
        {
            return "Task is not updated";
        }
    }
    public List<Task> GetListOfAllTasks()
    {
        try
        {
            return taskGatewayObject.GetListOfAllTasks();
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }

    public List<Task> SearchTask(int? Status, string AssignedTo)
    {
        try
        {
            return taskGatewayObject.SearchTask(Status, AssignedTo);
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }

    public List<Taskobj> GetAllTasksOfAProject(int projectId)
    {
        try
        {
            return taskGatewayObject.SelectAllTasksOfTheProject(projectId);
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }

    public List<Taskobj> GetAllOpenTasksOfAProject(int projectID, int? employeeID)
    {
        try
        {
            return taskGatewayObject.SelectAllOpenTaskOfTheProject(projectID, employeeID);
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }

    public Taskobj SelectTask(int taskId)
    {
        try
        {
            return taskGatewayObject.SelectTask(taskId);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public string ForwardATask(Taskobj taskObj)
    {
        bool isForwarded = false;
        var employeeName = "";
        try
        {
            isForwarded = taskGatewayObject.UpdateTask(taskObj);
            if (isForwarded)
            {
                var employeeGateway = new EmployeeGateway();
                if (taskObj.task_Employee_Id != null)
                {
                    employeeName = employeeGateway.GetEmployeeById(taskObj.task_Employee_Id.Value).employee_Name;
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        if (isForwarded)
        {
            return "Task is forwarded to " + employeeName;
        }
        else
        {
            return "Forwarding failed";
        }
    }

    public List<Taskobj> GetAllOpenTasksOfAUser(int employeeID)
    {
        List<Taskobj> userAllTasks = null;
        try
        {
            TaskGateway taskGatewayObj = new TaskGateway();
            userAllTasks = taskGatewayObj.GetAllOpenTasksOfAUser(employeeID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return userAllTasks;
    }

    public string CloseTask(int taskId)
    {
        bool isSaved = false;
        try
        {
            TaskGateway taskGatewayObject = new TaskGateway();
            isSaved = taskGatewayObject.CloseTask(taskId);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        if (isSaved)
        {
            return "Task is closed.";
        }
        else
        {
            return "Task is still open. some problem occurs during closing the task. ";
        }
    }

}
