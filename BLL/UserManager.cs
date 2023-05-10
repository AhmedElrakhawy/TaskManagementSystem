using System;
using System.Data;
using System.Configuration;
using System.Web;

using System.Collections.Generic;
using System.Data.SqlClient;
using DAL;

public class UserManager
{
    private UserGateway userGatewayObj = new UserGateway();
    private EmployeeGateway EmployeeGatewayobj = new EmployeeGateway();
    public string CreateUser(Userobj userObj,Employeeobj employeeobj)
    {
        bool isCreated = false;
        try
        {
           
            isCreated = EmployeeGatewayobj.InsertEmployee(employeeobj);
            if (isCreated)
            {
                var employee = EmployeeGatewayobj.GetEmployeeByName(employeeobj.employee_Name);
                userObj.user_employee_Id = employee.employee_Id;
                if (userGatewayObj.InsertUser(userObj))
                {
                    return "User created successfully! ";
                }
                else
                {
                    return "Failed to create user";
                }
            }
            else
            {
                return "Failed to create user";
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public string CheckUserIdAndPassword(int userId, string password)
    {
        try
        {
            UserGateway userGatewayObj = new UserGateway();
            return userGatewayObj.CheckUserIdAndPassword(userId, password);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<Userobj> GetAllUsers()
    {
        try
        {
            UserGateway userGatewayObj = new UserGateway();
            return userGatewayObj.GetAllUsers();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public bool IsAdmin(int userId)
    {
        try
        {
            UserGateway userGatewayObject = new UserGateway();
            string userType = userGatewayObject.GetUserType(userId);
            if (userType == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public string GetUserType(int userId)
    {
        try
        {
            UserGateway userGatewayObject = new UserGateway();
            return userGatewayObject.GetUserType(userId);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public string EditUserType(Userobj userObject)
    {
        try
        {
            UserGateway userGatewayObject = new UserGateway();
           

            bool isUpdated = userGatewayObject.EditUserType(userObject);

            if (isUpdated)
            {
                return userObject.user_Id + " is now " + userObject.user_AuthenticationMode;
            }
            else
            {
                return "User type is not updated ";
            }
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }
}
