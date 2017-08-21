using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GATE.Models {

    public class CourseViewModel {
        [Key]
        public int Id { get; set; }

        public int Code { get; set; }

        public string Title { get; set; }

        public short Fee { get; set; }

        [DisplayName("Level")]
        public int LevelId { get; set; }

    }

    public class StudentCoursesViewModel {
        public IEnumerable<Course> Courses { get; set; }
    }
}