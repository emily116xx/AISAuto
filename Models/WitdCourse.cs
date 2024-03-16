using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AISAutoForms.Models
{
    public class WitdCourse
    {
        [Key]
        public int WitdCourseId { get; set; }

        [DisplayName("Course Code")]
        [Required]
        public string WitdCourseCode { get; set; }

        [DisplayName("Course Name")]
        [Required]
        public string WitdCourseName { get; set; }

        //Relationship: ChgCourse
        public int ChgCourseId { get; set; }        // Foreign Key  
        public ChgCourse ChgCourse { get; set; }
    }
}

