using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GATE.Models;

namespace GATE.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public int Fee { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }
        public DateTime? LastUpdate { get; set; }

        // Foreign Keys
        public int? CourseId { get; set; }

        // Navigation Properties
        public virtual Course Course { get; set; }

        // ICollection Properties
        public virtual ICollection<StudentTests> StudentTests { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}