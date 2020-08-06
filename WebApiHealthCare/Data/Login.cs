using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiHealthCare.Data
{
    public class Login
    {
        [Key]
        public int Loginid { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Gender { get; set; }
        public string SocialLoginType { get; set; }
        public string Token { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DateOfBirth { get; set; }

        //public ICollection<Staffs> Staffs { get; set; }
        [NotMapped]
        public ICollection<TestResults> TestResults { get; set; }
    }
}
