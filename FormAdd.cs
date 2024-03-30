using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab3
{
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            string studentID = tbxID.Text;
            string firstName = tbxFirstName.Text;
            string lastName = tbxLastName.Text;
            string ageText = tbxAge.Text;
            int age;
            string gender = tbxGender.Text;
            string className = tbxCLassName.Text;
            string grade = tbxGrade.Text;

           
            if (string.IsNullOrWhiteSpace(studentID))
            {
                MessageBox.Show("Student ID cannot be empty.");
                return;
            }

            if (StudentDB.IsStudentIDExists(studentID))
            {
                MessageBox.Show("A student with this ID already exists. Please use a different ID.");
                return;
            }

            if (string.IsNullOrWhiteSpace(firstName) || !firstName.All(char.IsLetter))
            {
                MessageBox.Show("First name must be all letters and cannot be empty.");
                return;
            }

            
            if (string.IsNullOrWhiteSpace(lastName) || !lastName.All(char.IsLetter))
            {
                MessageBox.Show("Last name must be all letters and cannot be empty.");
                return;
            }

          
            if (!int.TryParse(ageText, out age) || age <= 0)
            {
                MessageBox.Show("Please enter a valid age.");
                return;
            }


            if (string.IsNullOrWhiteSpace(className))
            {
                MessageBox.Show("Class Name cannot be empty.");
                return;
            }

    
            if (string.IsNullOrWhiteSpace(grade))
            {
                MessageBox.Show("Grade cannot be empty.");
                return;
            }

            try
            {
                Student student = new Student
                {
                    StudentID = studentID,
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Gender = gender,
                    ClassName = className,
                    Grade = grade
                };

                List<Student> students = new List<Student> { student };
                StudentDB.SaveStudents(students);
                MessageBox.Show("Student saved successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        private void FormAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
