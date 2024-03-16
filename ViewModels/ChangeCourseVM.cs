using AISAutoForms.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AISAutoForms.ViewModels
{
    public class ChangeCourseVM
    {

        [DisplayName("Student ID")]
        [Required(ErrorMessage = "Student ID is required.")]
        //[Key] => originally commented out
        [DatabaseGenerated(DatabaseGeneratedOption.None)]   // this will disable the value generation that has been setup by convention. https://learn.microsoft.com/en-us/ef/core/modeling/generated-properties?tabs=data-annotations
        public int StudentId { get; set; }
        [DisplayName("Student Name")]
        [Required(ErrorMessage = "Student name is required.")]        
        public string StudentName { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required.")]
        public string StudentEmail { get; set; }
        [DisplayName("Phone No")]
        public string StudentPhone { get; set; }
        [DisplayName("Address")]
        public string StudentAddress { get; set; }
        [DisplayName("Programme of Study")]
        [Required(ErrorMessage = "Programme of study is required.")]
        public string ProgrammeOfStudy { get; set; }


        [DisplayName("Request Type")]
        public bool WithdrawFromCourse { get; set; }

        [DisplayName("Request Type")]
        public bool AddAnotherCourse { get; set; }

        [NotMapped] // Exclude from EF Core migrations
        public List<string> ChgCourseTypes { get; set; }
        public string ChgCourseType
        {
            get
            {
                var types = new List<string>();
                if (WithdrawFromCourse)
                {
                    types.Add("Withdraw from a Course");
                }
                if (AddAnotherCourse)
                {
                    types.Add("Add Another Course");
                }
                return string.Join(",", types);
            }
            set
            {
                ChgCourseTypes = value?.Split(',').ToList();
                WithdrawFromCourse = ChgCourseTypes?.Contains("Withdraw from a Course") ?? false;
                AddAnotherCourse = ChgCourseTypes?.Contains("Add Another Course") ?? false;
            }
        }

        //public int ChgCourseId { get; internal set; }
        //[DisplayName("Request Type")]
        //public string ChgCourseType { get; set; }        
        public string Signature { get; set; }
        [DisplayName("Date Requested")]
        [Required(ErrorMessage = "Submit date is required.")]
        public DateTime SubmitDate { get; set; }

        [DisplayName("Course Code")]
        [Required(ErrorMessage = "Course code is required.")]
        public string CourseCode { get; set; }
        [DisplayName("Course Name")]
        [Required(ErrorMessage = "Course name is required.")]
        public string CourseName { get; set; }

        [DisplayName("Course Code")]
        [Required(ErrorMessage = "Course code is required.")]
        public string WitdCourseCode { get; set; }
        [DisplayName("Course Name")]
        [Required(ErrorMessage = "Course name is required.")]
        public string WitdCourseName { get; set; }

        [DisplayName("Course Code")]
        [Required(ErrorMessage = "Course code is required.")]
        public string AddCourseCode { get; set; }
        [DisplayName("Course Name")]
        [Required(ErrorMessage = "Course name is required.")]
        public string AddCourseName { get; set; }
        
    }

}
