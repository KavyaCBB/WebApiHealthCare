using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiHealthCare.Data
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int RoleValue { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        //public ICollection<Staffs> Staffs { get; set; }
    }

}

