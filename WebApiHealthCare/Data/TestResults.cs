using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiHealthCare.Data
{
    public class LabTests
    {
        [Key]
        public int TestId { get; set; }
        public string TestName { get; set; }
        public float MaxRange { get; set; }
        public float MinRange { get; set; }
        public string Details { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}
