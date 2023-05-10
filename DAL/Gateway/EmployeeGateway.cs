using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Generic;
using DAL;
using System.Linq;
using DAL.MappingClasses;

public class EmployeeGateway
{
   
    public bool InsertEmployee(Employeeobj employeeobj)
    { 
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var employee = EmployeeMapping.EmployeeObjToUserDb(employeeobj);
                context.Employees.Add(employee);
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
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }
        
    }

    public bool UpdateEmployee(Employeeobj employeeObj)
    {
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var employee = EmployeeMapping.EmployeeObjToUserDb(employeeObj);
                context.Entry(employee).State = EntityState.Modified;
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
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }
    }

    public Employeeobj GetEmployeeByName(string employeeName)
    {
        Employeeobj employeeobj = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                
                var employee = context.Employees.Where(x => x.employee_Name == employeeName).FirstOrDefault();
                employeeobj = EmployeeMapping.EmployeedbToEmployeeobj(employee);
               
            }
        }
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }
        return employeeobj;
    }

    public List<int> GetEmployeesIds()
    {
        List<int> employeesIdsobjList =  new List<int>();
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var employees = context.Employees.ToList();
                foreach (var emp in employees)
                {
                    employeesIdsobjList.Add(emp.employee_Id);
                }
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }

        return employeesIdsobjList;
    }

    public Employeeobj GetEmployeeById(int employeeId)
    {
        Employeeobj employeeobj = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {

                var employee = context.Employees.Where(x => x.employee_Id == employeeId).FirstOrDefault();
                employeeobj = EmployeeMapping.EmployeedbToEmployeeobj(employee);

            }
        }
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }
        return employeeobj;
    }

    public List<Employeeobj> GetAllNonMemberEmployeeOfAProjrct(int projectID)
    {
        List<Employeeobj> employeeobjList = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var ProjectTasks = context.Tasks.Where(x => x.task_Project_Id != projectID);
                List<Employee> employees = null;
                foreach (var Task in ProjectTasks)
                {
                    employees.Add(context.Employees.Find(Task.task_Employee_Id));
                }
                foreach (var employee in employees)
                {
                    employeeobjList.Add(EmployeeMapping.EmployeedbToEmployeeobj(employee));
                }
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }

        return employeeobjList;
    }

    public List<Employeeobj> GetAllEmployeesOfAProject(int projectID)
    {
        List<Employeeobj> employeeobjList = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var ProjectTasks = context.Tasks.Where(x => x.task_Project_Id == projectID);
                List<Employee> employees = null;
                foreach (var Task in ProjectTasks)
                {
                    employees.Add(context.Employees.Find(Task.task_Employee_Id));
                }
                foreach (var employee in employees)
                {
                    employeeobjList.Add(EmployeeMapping.EmployeedbToEmployeeobj(employee));
                }
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }

        return employeeobjList;
    }

    public List<Employeeobj> GetAllEmployees()
    {
        List<Employeeobj> employeeobjList = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var employees  = context.Employees.ToList();
                foreach (var employee in employees)
                {
                    employeeobjList.Add(EmployeeMapping.EmployeedbToEmployeeobj(employee));
                }
            }
        }
       
        catch (Exception ex)
        {
            throw ex;
        }
       
        return employeeobjList;
    }
    public string GetUserType(int employeeId)
    {
        string employeeType = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                employeeType = context.Employees.Find(employeeId).employee_AuthenticationMode;
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }

        return employeeType;
    }
    
    public bool EditemployeeType(Employeeobj employeeobj)
    {
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var employee = EmployeeMapping.EmployeeObjToUserDb(employeeobj);
                context.Entry(employee).State = EntityState.Modified;
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
