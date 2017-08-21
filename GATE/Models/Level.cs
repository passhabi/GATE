using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GATE.Models
{
    public class Level
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, 1000)]
        public short Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }
        public DateTime? LastUpdate { get; set; }

        // ICollection Property
        public virtual ICollection<Course> Courses { get; set; }
    }
}