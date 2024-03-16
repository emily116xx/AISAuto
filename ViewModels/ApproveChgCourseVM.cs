using AISAutoForms.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AISAutoForms.ViewModels
{
    public class ApproveChgCourseVM    
    {
        public int ChgCourseId { get; set; }

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
        public string Status { get; set; }

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

        //For Program Admin
        [DisplayName("Approver Name")]
        public string ApproverName { get; set; }

        [DisplayName("Approver Role")]
        public string ApproverRole { get; set; }

        [DisplayName("Department")]
        public string ApproverDept { get; set; }

        [DisplayName("Date")]
        public DateTime ApproverDate { get; set; }

        [DisplayName("Comments")]
        public string ApproverComments { get; set; }

        //For Registry
        [DisplayName("Registrar Name")]
        public string RegistrarName { get; set; }

        [DisplayName("Process Date")]
        public DateTime ProcessDate { get; set; }

        [DisplayName("Date Returned from Accounts")]
        public DateTime ReturnedDate { get; set; }

        [DisplayName("Transcript Updated")]
        public string TranscriptUpdate { get; set; }

        [DisplayName("Comments")]
        public string Comments { get; set; }

        //For Accounting Department

        [DisplayName("Process By")]
        public string ProcessBy { get; set; }

        //[DisplayName("Course Change applied for within first 7 days of course commencement date?")]
        [DisplayName("Course Change")]
        public bool IsChange { get; set; }          // Yes or No

        //[DisplayName("Course withdrawal applied for within first 7 days of course commencement date?")]
        [DisplayName("Course Withdrawal")]
        public bool IsWithdrawal { get; set; }      // Yes or No

        [DisplayName("Invoice to be cancelled?")]        
        public bool IsCancelled { get; set; }       // Yes or No

        [DisplayName("New Invoice Required?")]        
        public bool IsRequired { get; set; }        // Yes or No

        [DisplayName("Amount for Payment")]        
        public double PaymentAmt { get; set; }

        [DisplayName("Amount for Refund")]
        public double RefundAmt { get; set; }

        [DisplayName("Amt for Transfer to next intake")]
        public double TransferAmt { get; set; }

        //public DateTime ProcessDate { get; set; }   // Same name in the Approver table

    }

}

