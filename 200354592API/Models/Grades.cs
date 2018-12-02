using System;
using System.Collections.Generic;

namespace _200354592API.Models
{
    public partial class Grades
    {
        public Grades()
        {
            Student = new HashSet<Student>();
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }
        public string Remarks { get; set; }

        public ICollection<Student> Student { get; set; }
    }
}
