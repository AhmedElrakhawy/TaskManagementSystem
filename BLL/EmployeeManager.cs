using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Data.SqlClient;

public class EmployeeManager
{
    private EmployeeGateway employeeGatewayObj = new EmployeeGateway();
    public string SaveEmployee(Employeeobj employeeObj)
    {
        bool isSaved = false;
        try
        {
            isSaved = employeeGatewayObj.InsertEmployee(employeeObj);
        }
       
        catch (Exception ex)
        {
            throw ex;
        }

        if (isSaved)
        {
            return "Employee has been saved";
        }
        else
        {
            return "Employee is not saved";
        }
    }
    public string UpdateEmployee(Employeeobj employeeObj)
    {
        bool isUpdate = false;
        try
        {
            isUpdate = employeeGatewayObj.UpdateEmployee(employeeObj);
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }

        if (isUpdate)
        {
            return "Employee has been updated";
        }
        else
        {
            return "Employee is not updated";
        }
    }
    public List<Employeeobj> GetAllEmployees()
    {
        try
        {
            return employeeGatewayObj.GetAllEmployees();
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }

    public List<int> GetEmployeesIds()
    {
        try
        {
            return employeeGatewayObj.GetEmployeesIds();
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }

    public Employeeobj GetEmployeeById(int employeeId)
    {
        try
        {
            EmployeeGateway employeeGateWay = new EmployeeGateway();
            return employeeGateWay.GetEmployeeById(employeeId);
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }

    public List<Employeeobj> GetEmployeesOfTheProject(int projectID)
    {
        try
        {
            EmployeeGateway employeeGateway = new EmployeeGateway();
            return employeeGateway.GetAllEmployeesOfAProject(projectID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    

    public List<Employeeobj> GetAllNonMemberEmployeeOfTheProject(int projectID)
    {
        try
        {
            return employeeGatewayObj.GetAllNonMemberEmployeeOfAProjrct(projectID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
