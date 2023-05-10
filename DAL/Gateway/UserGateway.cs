using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Generic;
using DAL;
using System.Linq;
using DAL.MappingClasses;

public class UserGateway
{

    public bool InsertUser(Userobj userObj)
    {  
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var user = UserMapping.UserObjToUserDb(userObj);
                context.tbUsers.Add(user);
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


    public List<Userobj> GetAllUsers()
    {
        List<Userobj> userListobj = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var userList = context.tbUsers.ToList();
                foreach (var user in userList)
                {
                   userListobj.Add(UserMapping.UserdbToUserobj(user));
                }
            }
        }
       
        catch (Exception ex)
        {
            throw ex;
        }
       
        return userListobj;
    }
    public string GetUserType(int userId)
    {
        string userType = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                userType = context.tbUsers.Find(userId).user_AuthenticationMode;
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }

        return userType;
    }
    public string CheckUserIdAndPassword(int userId, string password)
    {
        string userType = null;
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {

               var userdb = context.tbUsers.FirstOrDefault(x => x.user_Id == userId && x.user_Password == password);
                if (userdb != null)
                {
                    userType = userdb.user_AuthenticationMode;
                }
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }

        return userType;
    }

    public bool EditUserType(Userobj userObject)
    {
        try
        {
            using (TaskManagementDBEntities context = new TaskManagementDBEntities())
            {
                var user = UserMapping.UserObjToUserDb(userObject);
                context.Entry(user).State = EntityState.Modified;
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
