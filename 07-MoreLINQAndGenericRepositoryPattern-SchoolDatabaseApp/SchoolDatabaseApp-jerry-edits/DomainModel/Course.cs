//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DomainModel
{
    using System;
    using System.Collections.Generic;

    public partial class Course : IEntity
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public System.Data.Spatial.DbGeography Location { get; set; }
        public Nullable<int> TeacherId { get; set; } // TODO: <----
        public virtual Teacher Teacher { get; set; } // TODO: <----
        public virtual ICollection<Student> Students { get; set; }

        public EntityState EntityState { get; set; }
    }
}
