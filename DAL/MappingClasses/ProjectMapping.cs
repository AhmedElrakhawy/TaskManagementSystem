using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MappingClasses
{
    public class ProjectMapping
    {
        public static Project ProjectObjToProjectDb(Projectobj projectobj)
        {
            return new Project
            {
                project_Id = projectobj.project_Id,
                project_Description = projectobj.project_Description,
                project_StartTime = projectobj.project_StartTime,
                project_Status = projectobj.project_Status,
                project_Title = projectobj.project_Title,
                Tasks = projectobj.Tasks,
            };
        }
        public static Projectobj ProjectdbToProjectobj(Project projectdb)
        {
            return new Projectobj
            {
                project_Id = projectdb.project_Id,
                project_Description = projectdb.project_Description,
                project_StartTime = projectdb.project_StartTime.Value,
                project_Status = projectdb.project_Status.Value,
                project_Title = projectdb.project_Title,
                Tasks = projectdb.Tasks.ToList(),
            };
        }
    }
}
