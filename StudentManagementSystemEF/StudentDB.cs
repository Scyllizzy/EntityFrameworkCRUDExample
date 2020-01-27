using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemEF
{
    public static class StudentDB
    {
        /// <summary>
        /// Returns a list of all the students sorted by StudentID in ascending order
        /// </summary>
        public static List<Student> GetAllStudents()
        {
            using (var context = new StudentContext())
            {
                // LINQ - Language INtegrated Query

                // LINQ Query Syntax
                List<Student> students =
                    (from s in context.Students // for every row in students table
                 orderby s.StudentID ascending
                     select s).ToList();

                // LINQ Method Syntax
                List<Student> students2 = context.Students.OrderBy(stu => stu.StudentID).ToList();

                return students;
            }
        }

        public static Student Add(Student stu)
        {
            using (var context = new StudentContext())
            {
#if DEBUG
                //Log query generated to output window
                context.Database.Log = Console.WriteLine;
#endif
                // Preparing an insert query
                context.Students.Add(stu);

                //Executing the insert query against the database
                context.SaveChanges();

                // Return the student with the StudentID set
                return stu;
            }
        }

        /// <summary>
        /// Deletes a student from the database by their studentID
        /// </summary>
        /// <param name="stu">The student to be deleted</param>
        public static void Delete(Student stu)
        {
            using(StudentContext context = new StudentContext())
            {
                context.Students.Attach(stu);
                context.Entry(stu).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates all student data (except for PK)
        /// </summary>
        /// <param name="stu">The student to be updated</param>
        /// <returns></returns>
        public static Student Update(Student stu)
        {
            using (var context = new StudentContext())
            {
                context.Students.Attach(stu);
                context.Entry(stu).State = EntityState.Modified;
                context.SaveChanges();
                return stu;
            }
        }

        /// <summary>
        /// If the studentID is 0, they will be added to the database.
        /// Otherwise it will updated based on the studentID
        /// </summary>
        /// <param name="stu">The student to be added or updated</param>
        /// <returns></returns>
        public static Student AddOrUpdate(Student stu)
        {
            using (var context = new StudentContext())
            {
                context.Entry(stu).State = (stu.StudentID == 0) ? EntityState.Added: EntityState.Modified;
                context.SaveChanges();
                return stu;
            }
        }
    }
}
