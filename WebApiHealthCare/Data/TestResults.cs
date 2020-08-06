using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiHealthCare.Data
{
    public class TestResults
    {
        [Key]
        public int TestId { get; set; }
        public string TestName { get; set; }
        public float MaxRange { get; set; }
        public float MinRange { get; set; }
        public float PatientRange { get; set; }
        public string Details { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        [ForeignKey("Loginid")]
        public virtual Login Login { get; set; }

    }
}
