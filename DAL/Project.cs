//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        public Project()
        {
            this.Tasks = new HashSet<Task>();
        }
    
        public int project_Id { get; set; }
        public string project_Title { get; set; }
        public string project_Description { get; set; }
        public Nullable<System.DateTime> project_StartTime { get; set; }
        public Nullable<int> project_Status { get; set; }
    
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
