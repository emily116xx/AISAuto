using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace AISAutoForms.Models
{
    public class Student
    {
        [DisplayName("Student ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]   // this will disable the value generation that has been setup by convention. https://learn.microsoft.com/en-us/ef/core/modeling/generated-properties?tabs=data-annotations
        public int StudentId { get; set; }          

        [DisplayName("Student Name")]
        [Required]
        public string StudentName { get; set; }

        [DisplayName("Email")]
        [Required]
        public string StudentEmail { get; set;}

        [DisplayName("Phone No")]
        public string StudentPhone { get; set;}
        [DisplayName("Address")]
        public string StudentAddress { get; set; }

        [DisplayName("Programme of Study")]
        [Required]
        public string ProgrammeOfStudy { get; set;}

        //Relationship: ChgCourse
        public ICollection<ChgCourse> ChgCourses { get; set;}        

    }
}
