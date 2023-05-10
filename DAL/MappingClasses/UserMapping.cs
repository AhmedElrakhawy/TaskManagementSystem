using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MappingClasses
{
    public class UserMapping
    {
        public static tbUser UserObjToUserDb(Userobj userobj)
        {
            return new tbUser
            {
                user_Id = userobj.user_Id,
                user_CreatedDate = DateTime.Now,
                user_employee_Id = userobj.user_employee_Id,
                user_Password = userobj.user_Password,
                user_AuthenticationMode = userobj.user_AuthenticationMode,
            };
        }
        public static Userobj UserdbToUserobj(tbUser user)
        {
            return new Userobj
            {
                user_Id = user.user_Id,
                user_CreatedDate = user.user_CreatedDate.Value,
                user_employee_Id = user.user_employee_Id.Value,
                user_AuthenticationMode = user.user_AuthenticationMode,
            };
        }
    }
}
