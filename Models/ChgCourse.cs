using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AISAutoForms.Models
{
    public class ChgCourse
    {

        [Key]
        public int ChgCourseId { get; set; }

        [DisplayName("Request Type")]
        public string ChgCourseType { get; set; }

        public string Status { get; set; }

        public string Signature { get; set; }

        [DisplayName("Date Requested")]
        public DateTime SubmitDate { get; set; }

        //Relationships        
        public ICollection<AddCourse> AddCourses { get; set; }         // One to many. ChgCourse can  have multiple AddCourses.
        public ICollection<EnrCourse> EnrCourses { get; set; }         // One to many. ChgCourse can  have multiple EnrCourses.
        public ICollection<WitdCourse> WitdCourses { get; set; }       // One to many. ChgCourse can  have multiple WitdCourses.
        public ICollection<Approver> Approvers { get; set; }           // One to many. ChgCourse can  have multiple Approvers.

        public int StudentId { get; set; }                              // One to many. Student can have multiple Change Course.
        public Student Student { get; set; }

        public Account Account { get; set; }                            // One to one
        //public int AccountId { get; set; }

        public Registrar Registrar {  get; set; }                       // One to one
        //public int RegistrarId { get; set; }
        //public List<Student> Students { get; set; }                   // One to one
        //public List<Account> Accounts { get; set; }                    // One to one
        //public List<Registrar> Registrars { get; set; }               // One to one



    }
   
}
