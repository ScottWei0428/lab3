using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lab3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load; 
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadStudentsIntoDataGridView();
        }

        public void LoadStudentsIntoDataGridView()
        {
            dataGridViewStudents.AutoGenerateColumns = true;

            dataGridViewStudents.DataSource = null;


            if (!System.IO.File.Exists(StudentDB.Path))
            {
                dataGridViewStudents.DataSource = new List<Student>(); 
                                                                       
                MessageBox.Show("No student data file found. Please add new students.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           
            List<Student> studentsFromFile = StudentDB.FetchStudents();
            dataGridViewStudents.DataSource = studentsFromFile;
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAdd formAdd = new FormAdd();
            var dialogResult = formAdd.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                LoadStudentsIntoDataGridView(); 
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a cell in the row you wish to delete.");
                return;
            }

            var rowIndex = dataGridViewStudents.SelectedCells[0].RowIndex;
            var studentIDToDelete = dataGridViewStudents.Rows[rowIndex].Cells["StudentID"].Value.ToString();

            var studentsFromFile = StudentDB.FetchStudents();
            var filteredStudents = studentsFromFile.Where(student => student.StudentID != studentIDToDelete).ToList();

            StudentDB.SaveStudents(filteredStudents,false); 
            LoadStudentsIntoDataGridView(); 

            MessageBox.Show("Student deleted successfully!");
        }

        private bool IsValidStudent(Student student, string originalStudentID, List<Student> existingStudents, out string errorMessage)
        {
            errorMessage = "";

            
            if (string.IsNullOrWhiteSpace(student.StudentID))
            {
                errorMessage = "Student ID cannot be empty.";
                return false;
            }

            
            
            if (existingStudents.Any(s => s.StudentID == student.StudentID && s.StudentID != originalStudentID))
            {
                errorMessage = $"Student ID {student.StudentID} already exists.";
                return false;
            }


            if (student.FirstName.Any(char.IsDigit) || student.LastName.Any(char.IsDigit) ||
                student.FirstName.Any(ch => !char.IsLetter(ch) && !char.IsWhiteSpace(ch)) ||
                student.LastName.Any(ch => !char.IsLetter(ch) && !char.IsWhiteSpace(ch)))
            {
                errorMessage = "Name cannot contain numbers or special characters.";
                return false;
            }

            

            

            return true; 
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var updatedStudents = new List<Student>();
            var errorMessage = "";


            var existingStudents = StudentDB.FetchStudents();

            foreach (DataGridViewRow row in dataGridViewStudents.Rows)
            {
                if (row.IsNewRow) continue; 

 
                var student = new Student
                {
                    StudentID = Convert.ToString(row.Cells["StudentID"].Value),
                    FirstName = Convert.ToString(row.Cells["FirstName"].Value),
                    LastName = Convert.ToString(row.Cells["LastName"].Value),
                    Age = Convert.ToInt32(row.Cells["Age"].Value),
                    Gender = Convert.ToString(row.Cells["Gender"].Value),
                    ClassName = Convert.ToString(row.Cells["ClassName"].Value),
                    Grade = Convert.ToString(row.Cells["Grade"].Value),
                };


                string originalStudentID = student.StudentID;

  
                if (!IsValidStudent(student, originalStudentID, existingStudents, out errorMessage))
                {
                    MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    LoadStudentsIntoDataGridView();
                    return;
                }

                updatedStudents.Add(student);
            }


            StudentDB.SaveStudents(updatedStudents, false);
            MessageBox.Show("Students updated successfully!");

         
            LoadStudentsIntoDataGridView();
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchText = tbxSearch.Text.ToLower();
            var students = StudentDB.FetchStudents();
            var filteredStudents = students.Where(s => s.StudentID.ToLower().Contains(searchText) ||
                                                        s.FirstName.ToLower().Contains(searchText) ||
                                                        s.LastName.ToLower().Contains(searchText)).ToList();
            dataGridViewStudents.DataSource = filteredStudents;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStudentsIntoDataGridView(); 
            tbxSearch.Text = ""; 
        }
    }
}
