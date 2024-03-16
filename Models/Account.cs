using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AISAutoForms.Models
{
    public class Account
    {
		[Key]
		public int AccountId { get; set; }

        public bool IsChange { get; set; }          // Yes or No
        public bool IsWithdrawal { get; set; }      // Yes or No

        [DisplayName("Invoice to be Cancelled?")]
        public bool IsCancelled { get; set; }       // Yes or No
        [DisplayName("New Invoice Required?")]
        public bool IsRequired { get; set; }        // Yes or No
        [DisplayName("Payment Amt")]
        public double PaymentAmt { get; set; }
        [DisplayName("Refund Amt")]
        public double RefundAmt { get; set; }
        [DisplayName("Amt for Transfer")]
        public double TransferAmt { get; set; }

        [DisplayName("Processed By")]
        public string ProcessBy { get; set; }

        [DisplayName("Date")]
        public DateTime ProcessDate { get; set; }

        //Relationship: ChgCourse        
        public ChgCourse ChgCourse { get; set; }        
        public int ChgCourseId { get; set; }
    }
}
