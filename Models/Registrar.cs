using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AISAutoForms.Models
{
    public class Registrar
    {
		[Key]
		public int RegistrarId { get; set; }

        [DisplayName("Registrar Name")]
        public string RegistrarName { get; set; }

        [DisplayName("Comments")]
        public string Comments { get; set; }

        [DisplayName("Processed Date")]
        public DateTime ProcessDate {  get; set; }

        [DisplayName("Returned Date")]
        public DateTime ReturnedDate { get; set; }                  // date returned from Accounts

        [DisplayName("Transcript Updated")]
        public string TranscriptUpdate {  get; set; }               // this is a checkbox. will have a  maximum of 5 chars. 

        //Relationship: ChgCourse
        public ChgCourse ChgCourse { get; set; }
        public int ChgCourseId { get; set; }
    }
}
