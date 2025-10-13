using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(50)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Phone(ErrorMessage ="Invalid phone number")]
        [Display(Name = "Phone Number")]
        public String Phonenumber { get; set; }

        [Range(1,100)]
        public int Age { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }

    }
}
