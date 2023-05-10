using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Data.SqlClient;
using DAL;

/// <summary>
/// This class manages every thing about Project
/// contains methods to manage project related oparations
/// </summary>
public class ProjectManager
{
    public List<Projectobj> GetAllProjectsOfUser(int employeeId)
    {
        try
        {
            ProjectGateway projectGatewayObj = new ProjectGateway();
            return projectGatewayObj.GetProjectsOfUser(employeeId);
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }

    public string UpdateProject(Projectobj projectObj)
    {
        bool isSaved = false;
        try
        {
            ProjectGateway projectGatewayObj = new ProjectGateway();
            isSaved = projectGatewayObj.UpdateProject(projectObj);
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }

        if (isSaved)
        {
            return "Project has been updated.";
        }
        else
        {
            return "Project is not updated";
        }
    }

    public Projectobj SelectProject(int projectId)
    {
        try
        {
            ProjectGateway projectGatewayObject = new ProjectGateway();
            return projectGatewayObject.SelectProject(projectId);
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }

    public List<Project> GetAllOpenProjects()
    {
        try
        {
            ProjectGateway projectGatewayObject = new ProjectGateway();
            return projectGatewayObject.SelectAllOpenProjects();
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }

    public string SaveProject(Projectobj projectObj)
    {
        bool isSaved = false;
        try
        {
            ProjectGateway projectGatewayObj = new ProjectGateway();

            isSaved = projectGatewayObj.InsertProject(projectObj);
        }
       
        catch (Exception ex)
        {
            throw ex;
        }

        if (isSaved)
        {
            return "Project has been saved.";
        }
        else
        {
            return "Project is not saved";
        }
    }



    public string CloseProject(int projectId)
    {
        bool isClosed = false;
        try
        {
            ProjectGateway projectGatewayObject = new ProjectGateway();
            isClosed = projectGatewayObject.CloseProject(projectId);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        if (isClosed)
        {
            return "Project is closed";
        }
        else
        {
            return "Project is not closed";
        }
    }
    public string RemovedEmployeeFromProject(int projectId , int employeeId)
    {
        bool IsRemoved = false;
        try
        {
            ProjectGateway projectGatewayObject = new ProjectGateway();
            IsRemoved = projectGatewayObject.RemoveEmployeeFromProject(projectId , employeeId);
        }
       
        catch (Exception ex)
        {
            throw ex;
        }

        if (IsRemoved)
        {
            return "Employee is removed";
        }
        else
        {
            return "Employee is not removed";
        }
    }

}
