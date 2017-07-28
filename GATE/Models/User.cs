using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web;

namespace GATE.Models
{

    public enum UserTypes
    {
        Student = 0,
        Teacher = 1,
        Staff = 2
    }

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        [DisplayName("Confirm password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Email Address")]
        [EmailAddress(ErrorMessage = "Enter a valid Email Address")]
        public string Email { get; set; }

        //ADD a Regular Expression
        [DisplayName("Cell Phone")]
        public int? CellPhone { get; set; }

        [Required]
        public bool Confirmed { get; set; }

        public UserTypes UserType { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }
        public DateTime? LastUpdate { get; set; }

        // ForeignKeys
        public int? StudentId { get; set; }
        public int? StaffId { get; set; }

        // Navigation Properties
        public virtual Student Student { get; set; }
        public virtual Staff Staff { get; set; }
    }
}