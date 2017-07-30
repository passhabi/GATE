using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace GATE.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [DisplayName("Nike Name")]
        public string NickName { get; set; }

        [DisplayName("Family Name")]
        [MaxLength(50)]
        [Required(ErrorMessage = "The field Family Name is Required")]
        public string FamilyName { get; set; }

        // Identity
        [DisplayName("National Code")]
        [RegularExpression("\\d{10}",
            ErrorMessage = "The national code is not valid, Consider entering the national code without hyphen")]
        public int NationalCode { get; set; }

        [MaxLength(50)]
        [DisplayName("Father's Name")]
        public string FathersName { get; set; }

        // ToDo: Add Regular Expression for Birthday
        public DateTime Birthday { get; set; }

        [MaxLength(50)]
        [DisplayName("Born In")]
        public string BornCity { get; set; }

        // ToDo: Add Regular Expression for TelephoneNumber
        public int? Telephone { get; set; }

        [RegularExpression("\\d{10}",
            ErrorMessage = "The national code is not valid, Consider entering the Postal Code without hyphen")]
        [DisplayName("Postal Code")]
        public int? PostalCode { get; set; }

        public string Address { get; set; }

        [Range(1, 999)]
        public int? Plaque { get; set; }

        [Required]
        [DisplayName("Student Number")]
        public int StudentNumber { get; set; }

        [Range(0,20)]
        public int? Gpa { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }
        public DateTime LastUpdate { get; set; }

        // ICollection Properties
        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
        public virtual ICollection<StudentTests> StudentTests { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        // public virtual ICollection<User> Users { get; set; }
    }
}