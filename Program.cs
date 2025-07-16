class Student
{
    private string name;
    private string rollNo;
    public string Name { get; set; }
    public string RollNo { get; set; }
    public List<Subject> Subjects { get; set; } 
    public Student(string name, string rollNo, List<Subject> subject)
    {
        Subjects = subject;
        this.name = name;
        this.rollNo = rollNo;
    }
    public Student() { }

    public void ShowStudentsAverage(List<Student> studentList)
    {
        Console.Clear();
        Console.WriteLine("Students Average:\n");
        Console.WriteLine("Roll No   Name       Average");
        Console.WriteLine("----------------------------------\n");
        foreach (var student in studentList)
        {
            Console.WriteLine("{0}     {1}         {2:0.00}",student.rollNo, student.name,student.marksAverage);
        }
        Console.Write("\nPress Enter to Go Back !");
        Console.ReadLine();
    }

    public void ShowStudentsList(List<Student> studentList)
    {
        Console.Clear();
        Console.WriteLine("List of all students:\n");
        Console.WriteLine("Roll No   Name       Subjects");
        Console.WriteLine("----------------------------------\n");
        foreach (Student student in studentList)
        {
            Console.Write(" {0}      {1}      ", student.rollNo, student.name);

            foreach (var subject in student.Subjects)
            {
                Console.Write("[" + subject.Name + "] ");
            }

            Console.WriteLine(); // New line after each student
        }
        Console.WriteLine();
        Console.Write("Press Enter to Go Back!");
        Console.ReadLine();
    }
    public double marksAverage => Subjects.Average(s => s.Marks);
    public bool isPassed => marksAverage >= 50;

    public void passedStudents(List<Student> studentList)
    {
        
        while(true)
        {
            Console.Clear();
            Console.Write("Enter the Roll No of Student (O for Exit) : ");
            var rollNo = Console.ReadLine();
            if (rollNo == "0") return;
            var student = studentList.FirstOrDefault(s => s.rollNo.Equals(rollNo));
            if (student == null)
            {
                Console.WriteLine("No student Found!");
            }
            else
                Console.WriteLine($"\nName : {student.name}   Roll No : {student.rollNo}   {(student.isPassed ? "Passed" : "Failed")} ");

            Console.Write("\nPress Enter to Go Back !");
            Console.ReadLine();
               
        }
    }
} 
class Subject
{
    public string Name { get; set; }
    public int Marks { get; set; }

    public Subject(string name, int marks)
    {
        Name = name;
        Marks = marks;
    }

}

public static partial class Program
    {
        public static void Main(string[] args)
        {
        var subjects1 = new List<Subject>
        {
            new Subject("Math",60),
            new Subject("Urdu",70),
            new Subject("English",80),

        };
        var subjects2 = new List<Subject>
        {
            new Subject("Math",60),
            new Subject("Pak-Studies",80),
            new Subject("Urdu",90),

        }; var subjects3 = new List<Subject>
        {
            new Subject("Islamiyat",20),
            new Subject("Math",30),
            new Subject("English",50),

        };
        var students = new List<Student>
            {
                new Student("Umer", "101",subjects1),
                new Student("Ali", "102",subjects2),
                new Student("Sara", "103",subjects3)
            };

            Student s = new Student();
  
        while (true)
        {
            Console.Clear();
            Console.WriteLine("*****Student Management System*******\n");
            Console.WriteLine("1. Display All Students ");
            Console.WriteLine("2. Display all Students Average");
            Console.WriteLine("3. Show Passed Students");
            Console.WriteLine("4. Exit\n");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    s.ShowStudentsList(students);
                    break;
                case "2":
                    s.ShowStudentsAverage(students);
                    break;
                case "3":
                    s.passedStudents(students);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid Input!");
                    break;
            }
        }
        }

    }

