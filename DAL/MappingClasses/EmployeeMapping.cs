using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MappingClasses
{
    public class EmployeeMapping
    {
        public static Employee EmployeeObjToUserDb(Employeeobj employeeobj)
        {
            return new Employee
            {
                employee_Id = employeeobj.employee_Id,
                employee_Name = employeeobj.employee_Name,
                employee_Email = employeeobj.employee_Email,
                employee_PhoneNumber = employeeobj.employee_PhoneNumber,
                employee_Address = employeeobj.employee_Address,
                employee_AuthenticationMode = employeeobj.employee_AuthenticationMode,
                employee_DateOfBirth = employeeobj.employee_DateOfBirth,
                employee_JoinDate = employeeobj.employee_JoinDate, 
                Tasks = employeeobj.Tasks,
            };
        }
        public static Employeeobj EmployeedbToEmployeeobj(Employee employee)
        {
            return new Employeeobj
            {
                employee_Id = employee.employee_Id,
                employee_Name = employee.employee_Name,
                employee_Email = employee.employee_Email,
                employee_PhoneNumber = employee.employee_PhoneNumber,
                employee_Address = employee.employee_Address,
                employee_AuthenticationMode = employee.employee_AuthenticationMode,
                employee_DateOfBirth = employee.employee_DateOfBirth,
                employee_JoinDate = employee.employee_JoinDate,
                Tasks = employee.Tasks.ToList(),
            };
        }
    }
}
