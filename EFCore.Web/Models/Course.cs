using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Web.Models
{
    //public class Course
    //{
    //    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    //    public int CourseID { get; set; }
    //    public string Title { get; set; }
    //    public int Credits { get; set; }

    //    public ICollection<Enrollment> Enrollments { get; set; }
    //}

    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "课程编号")]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "课程名称")]
        public string Title { get; set; }

        [Range(0, 5)]
        [Display(Name = "学分")]
        public int Credits { get; set; }

        public int DepartmentID { get; set; }

        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
    }
}
