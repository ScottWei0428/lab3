using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace lab3
{
    public class StudentDB
    {

        public static readonly string Path = @"D:\Application Dev using C#.Net - ITE-5230-IRA\Assignment3\Students.txt";

        public const char Delimiter = '|';

        public static List<Student> FetchStudents()
        {
            var fetchedStudents = new List<Student>();
            if (!File.Exists(Path))
            {
                return fetchedStudents;
            }

            using (StreamReader textIn = new StreamReader(new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read)))
            {
                string line;
                while ((line = textIn.ReadLine()) != null)
                {
                    var columns = line.Split(Delimiter);
                    if (columns.Length >= 7)
                    {
                        Student student = new Student
                        {
                            StudentID = columns[0],
                            FirstName = columns[1],
                            LastName = columns[2],
                            Age = int.TryParse(columns[3], out var age) ? age : 0,
                            Gender = columns[4],
                            ClassName = columns[5],
                            Grade = columns[6]
                        };
                        fetchedStudents.Add(student);
                    }
                }
            }

            return fetchedStudents;
        }

        public static bool IsStudentIDExists(string studentID)
        {
            var students = FetchStudents();
            return students.Any(student => student.StudentID == studentID);
        }

        public static void SaveStudents(List<Student> students, bool append = true)
        {
            try
            {
                using (StreamWriter textOut = new StreamWriter(new FileStream(StudentDB.Path, append ? FileMode.Append : FileMode.Create, FileAccess.Write)))
                {
                    foreach (Student student in students)
                    {
                        
                        string studentInfo = $"{student.StudentID}{Delimiter}" +
                                             $"{student.FirstName}{Delimiter}" +
                                             $"{student.LastName}{Delimiter}" +
                                             $"{student.Age}{Delimiter}" + 
                                             $"{student.Gender}{Delimiter}" +
                                             $"{student.ClassName}{Delimiter}" +
                                             $"{student.Grade}";

                        textOut.WriteLine(studentInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

    }
}
