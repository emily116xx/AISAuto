using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AISAutoForms.Models
{
    public class EnrCourse
    {
        [Key]
        public int EnrCourseId { get; set; }

        [DisplayName("Course Code")]
        [Required]
        public string CourseCode { get; set; }

        [DisplayName("Course Name")]
        [Required]
        public string CourseName { get; set; }

        //Relationship: ChgCourse
        public int ChgCourseId { get; set; }            // Foreign Key        
        public ChgCourse ChgCourse { get; set; }

    }
}
