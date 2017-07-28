using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GATE.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Fee is required; Enter 0 for free")]
        public short Fee { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }
        public DateTime LastUpdate { get; set; }

        // Foreign keys
        public int LevelId { get; set; }

        // Navigation Property
        public virtual Level Level { get; set; }

        // ICollection Property
        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}