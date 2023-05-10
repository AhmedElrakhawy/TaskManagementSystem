using System;
using System.Data;
using System.Configuration;
using System.Web;


public class DataValidator
{
 
    public static string EmailValidator(string emailID)
    {
        if (IsEmpty(emailID))
        {
            return "Email Id cant be empty";
        }
        else if (!IsEndWithDotCom(emailID))
        {
            return "Email Id must end with '.com'";
        
        }
        else if (!IsContainsAtTheRate(emailID))
        {
            return "Email Id must contain '@'";
        }
        else
        {
            return "";
        }
    }


    public static bool IsEmpty(string inputString)
    {
        if (inputString.Length == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
    public static bool IsNumber(string inputString)
    {
        double result;
        return double.TryParse(inputString, out result);
    }

   
    public static bool IsEndWithDotCom(string inputString)
    {
        return inputString.EndsWith(".com");
    }

   
    public static bool IsContainsAtTheRate(string inputString)
    {
        return inputString.Contains("@");
    }

   
    public static bool IsDate(string inputString)
    {
        DateTime result;
        return DateTime.TryParse(inputString, out result);
    }
}
