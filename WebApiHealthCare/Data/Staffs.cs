using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiHealthCare.Data
{
    public class Staffs
    {
        [Required]
        [Key]
        public int StaffID { get; set; }

        public string StaffName { get; set; }
        public string Designation { get; set; }
        public string ImagePath { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        [ForeignKey("RoleId")]
        public virtual Roles Roles { get; set; }
        //public virtual int RoleId { get; set; }

        [ForeignKey("Loginid")]
        public virtual Login Login { get; set; }
    }
}
