using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystemEF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Student stu = new Student()
            {
                FullName = "Simon Sadler",
                DateOfBirth = DateTime.Today
            };

            StudentDB.Add(stu);
            MessageBox.Show($"Student {stu.StudentID} added");

            List<Student> allStus = StudentDB.GetAllStudents();
            MessageBox.Show(allStus.Count.ToString());

            stu.FullName = "Alexia Sadler";
            StudentDB.Update(stu);
            MessageBox.Show("Updated");

            StudentDB.Delete(stu);
            MessageBox.Show("Student deleted");

            allStus = StudentDB.GetAllStudents();
            MessageBox.Show(allStus.Count.ToString());
        }
    }
}
