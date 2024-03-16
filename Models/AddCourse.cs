using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AISAutoForms.Models
{
    public class AddCourse
    {
        [Key]
        public int AddCourseId { get; set; }

        [DisplayName("Course Code")]
        [Required]
        public string AddCourseCode { get; set; }

        [DisplayName("Course Name")]
        [Required]
        public string AddCourseName { get; set; }

        //Relationship: ChgCourse
        public int ChgCourseId { get; set; }            // Foreign Key        
        public ChgCourse ChgCourse { get; set; }
    }
}

