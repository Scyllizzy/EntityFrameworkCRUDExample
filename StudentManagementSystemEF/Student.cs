using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemEF
{
    /// <summary>
    /// Represents a single student.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// The unique identifier for the student
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// The student's first and last name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The date and time the student was born
        /// </summary>
        public DateTime DateOfBirth { get; set; }
    }
}
