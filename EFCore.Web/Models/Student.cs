using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Web.Models
{
    //public class Student
    //{
    //    public int ID { get; set; }
    //    public string LastName { get; set; }
    //    public string FirstMidName { get; set; }
    //    public DateTime EnrollmentDate { get; set; }

    //    public ICollection<Enrollment> Enrollments { get; set; }
    //}
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "名")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "名字不能超过50个字符。")]
        [Column("FirstName")]
        [Display(Name = "姓")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "入学时间")]
        public DateTime EnrollmentDate { get; set; }
        [Display(Name = "姓名")]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstMidName;
            }
        }

        public ICollection<Enrollment> Enrollments { get; set; }
    }

}
