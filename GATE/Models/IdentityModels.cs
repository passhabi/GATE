using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GATE.Models
{
    public enum UserTypes
    {
        Admin = 0,
        Staff = 1,
        Teacher = 2,
        Student = 3,
    }

    public class CustomIdentityUser : IdentityUser
    {
        /*[NotMapped]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DisplayName("Confirm password")]
        public string ConfirmPassword { get; set; }*/


        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public UserTypes UserType { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }
        public DateTime? LastUpdate { get; set; }

        // UserTypeId pointing out to Staff and Student Model and 
        // there is no any relationship between CustomIdentityUser Model, Staff, and Student Model.
        public int UserTypeId { get; set; }

    }
}