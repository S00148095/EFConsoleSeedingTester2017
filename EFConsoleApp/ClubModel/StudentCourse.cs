using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClubModel
{
    [Table("StudentCourse")]
    public class StudentCourse
    {
        [Key, Column(Order = 1)]
        [Display(Name = "Student ID")]
        public string StudentID { get; set; }
        [Key, Column(Order = 2)]
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }

    }
}