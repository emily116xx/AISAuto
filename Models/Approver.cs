using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AISAutoForms.Models
{
    public class Approver
    {
		[Key]
		public int ApproverId { get; set; }

        [DisplayName("Approver Name")]
        public string ApproverName { get; set; }

        [DisplayName("Approver Role")]
        public string ApproverRole {  get; set; }

        [DisplayName("Department")]
        public string ApproverDept { get; set; }

        [DisplayName("Comments")]
        public string ApproverComments { get; set; }

        [DisplayName("Date")]
        public DateTime ApproverDate {  get; set; }


        //Relationship: ChgCourse
        public int ChgCourseId { get; set; }            // Foreign Key        
        public ChgCourse ChgCourse { get; set; }

    }
}
