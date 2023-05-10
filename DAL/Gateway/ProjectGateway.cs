using System;
using System.Data;
using System.Configuration;
using System.Web;

using System.Data.SqlClient;
using System.Collections.Generic;
using DAL;
using DAL.MappingClasses;
using DAL.DAO;
using System.Linq;
using System.Data.Entity;

/// <summary>
/// Gateway of project with DB
/// </summary>
public class ProjectGateway
{
    public bool InsertProject(Projectobj projectObj)
    {
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var project = ProjectMapping.ProjectObjToProjectDb(projectObj);
                context.Projects.Add(project);
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

    
    public bool RemoveEmployeeFromProject(int projectId , int EmployeeId)
    {
       
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var task = context.Tasks.Where(x => x.task_Employee_Id == EmployeeId && x.task_Project_Id == projectId).FirstOrDefault();
                if (task != null)
                {
                    task.task_Employee_Id = null;
                    if (context.SaveChanges() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

    
    public List<Projectobj> GetAllProjects()
    {
        List<Projectobj> projectobjList = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var projects = context.Projects.ToList();
                foreach (var project in projects)
                {
                    projectobjList.Add(ProjectMapping.ProjectdbToProjectobj(project));
                }
            }
        }
       
        catch (Exception ex)
        {
            throw ex;
        }
        return projectobjList;
    }

    public List<Project> SelectAllOpenProjects()
    {
        List<Project> projects = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                projects = context.Projects.Include(x => x.Tasks).Where(x => x.project_Status == 1).ToList();
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
        return projects;
    }

    public List<Projectobj> SelectAllOpenProjectsforanemployee(int employeeId)
    {
        List<Projectobj> projectobjList = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var Tasks = context.Tasks.Where(x => x.task_Employee_Id == employeeId && x.task_Status == 1);
                List<Project> Projects = null;
                foreach (var task in Tasks)
                {
                    Projects.Add(context.Projects.Find(task.task_Project_Id));
                }
                foreach (var project in Projects)
                {
                    projectobjList.Add(ProjectMapping.ProjectdbToProjectobj(project));
                }
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
        return projectobjList;

    }


    public Projectobj SelectProject(int projectId)
    {
        Projectobj projectobj = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                projectobj = ProjectMapping.ProjectdbToProjectobj(context.Projects.Find(projectId));
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
        return projectobj;
    }

 
    public bool UpdateProject(Projectobj projectObject)
    {
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var project =  ProjectMapping.ProjectObjToProjectDb(projectObject);
                context.Entry(project).State = EntityState.Modified;
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

    public List<Projectobj> GetProjectsOfUser(int employeeId)
    {
        List<Projectobj> projectsobj = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var tasks = context.Tasks.Where(x => x.task_Employee_Id == employeeId);
                foreach (var task in tasks)
                {
                    projectsobj.Add(ProjectMapping.ProjectdbToProjectobj(context.Projects.Find(task.task_Project_Id)));
                }
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
        return projectsobj;
    }


    public bool CloseProject(int projectId)
    {

        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var project =context.Projects.Find(projectId);
                project.project_Status = 0;
                context.Entry(project).State = EntityState.Modified;
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

}
