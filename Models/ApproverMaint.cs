using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AISAutoForms.Models
{
    public class ApproverMaint
    {
		//This is the Approver Maintenance Table where Admin can add, edit, delete any approver from any department.
		[Key]
		public int ApproverId { get; set; }

        [DisplayName("Name")]
        public string ApproverName { get; set; }

        [DisplayName("Role")]
        public string ApproverRole { get; set; }

        [DisplayName("Department")]
        public string ApproverDept { get; set; }
    }
}
