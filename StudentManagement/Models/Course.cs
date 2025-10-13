using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Full Course Name")]
        public string CourseName { get; set; }
        public string? TeacherName { get; set; }
    }
}
