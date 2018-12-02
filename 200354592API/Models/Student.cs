using System;
using System.Collections.Generic;

namespace _200354592API.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public int? GradeId { get; set; }

        public Grades Grade { get; set; }
    }
}
