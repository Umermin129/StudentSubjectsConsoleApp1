using System;
using System.Collections.Generic;

namespace StudentSubjectsConsoleApp
{
    public class Student
    {
        public string Name { get; set; }
        public string RollNo { get; set; }

        public Student(string name, string rollNo)
        {
            Name = name;
            RollNo = rollNo;
        }

        public void ShowStudentsList(List<Student> studentList)
        {
            Console.WriteLine("Here is the list of all students:");
            foreach (Student student in studentList)
            {
                Console.WriteLine("Roll No : {0}      Name : {1}", student.RollNo, student.Name);
            }
        }
    }
}
