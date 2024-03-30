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


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var tempStudents = new List<Student>(); 
            var studentIds = new HashSet<string>(); 
            bool hasDuplicateId = false; 

            foreach (DataGridViewRow row in dataGridViewStudents.Rows)
            {
                if (row.IsNewRow) continue; 

                var student = new Student
                {
                    StudentID = Convert.ToString(row.Cells["StudentID"].Value),
                    FirstName = Convert.ToString(row.Cells["FirstName"].Value),
                    LastName = Convert.ToString(row.Cells["LastName"].Value),
                    Age = row.Cells["Age"].Value != null ? Convert.ToInt32(row.Cells["Age"].Value) : 0,
                    Gender = Convert.ToString(row.Cells["Gender"].Value),
                    ClassName = Convert.ToString(row.Cells["ClassName"].Value),
                    Grade = Convert.ToString(row.Cells["Grade"].Value),
                };

                
                if (string.IsNullOrWhiteSpace(student.StudentID))
                {
                    MessageBox.Show("Student ID cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                if (!studentIds.Add(student.StudentID)) 
                {
                    MessageBox.Show($"Duplicate Student ID found: {student.StudentID}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hasDuplicateId = true;
                    break;
                }

                tempStudents.Add(student);
            }

            if (!hasDuplicateId)
            {
                
                StudentDB.SaveStudents(tempStudents, false); 
                MessageBox.Show("Students updated successfully!");
                LoadStudentsIntoDataGridView(); 
            }
            else
            {
                
                LoadStudentsIntoDataGridView();
            }
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
