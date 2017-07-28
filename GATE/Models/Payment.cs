﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GATE.Models;

namespace GATE.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        public string TrackingCode { get; set; }

        public bool Confirmed { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        // Foreign Key
        public int StudentId { get; set; }
        public int TestId { get; set; }
        public int CourseId { get; set; }

        // Navigation Properties
        public virtual Student Student { get; set; }
        public virtual Test Test { get; set; }
        public virtual Course Course { get; set; }
    }
}