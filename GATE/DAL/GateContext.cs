using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using GATE.Models;

namespace GATE.DAL
{
    public class GateContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }
        public DbSet<StudentTests> StudentTests { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Staff> Staves { get; set; }
        public DbSet<Payment> Payments { get; set; }

    }
}