using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiHealthCare.Data
{
    public class LabTestResults
    {
        [Key]
        public int TestResultsId { get; set; }
        public float PatientRange { get; set; }

        

        [ForeignKey("StaffID")]
        public virtual Staffs Staffs { get; set; }

        [ForeignKey("TestId")]
        public virtual LabTests LabTests { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        [ForeignKey("Loginid")]
        public virtual Login Login { get; set; }
    }
}
