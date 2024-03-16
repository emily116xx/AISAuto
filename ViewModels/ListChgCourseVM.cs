using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AISAutoForms.ViewModels
{
    public class ListChgCourseVM
    {

        [DisplayName("Request ID")]
        public int ChgCourseId { get; set; }

        [DisplayName("Student ID")]
        public int StudentId { get; set; }

        [DisplayName("Request Date")]
        public DateTime SubmitDate { get; set; }

        [DisplayName("Progress")]
        public string Status { get; set; }

    }
}
