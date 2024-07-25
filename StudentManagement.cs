using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagementSystem
{
    public class StudentManagement
    {
        private List<Student> students = new List<Student>();

        public void ManageStudents()
        {
            while (true)
            {
                    Console.WriteLine("Manage Students");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. Remove Student");
                    Console.WriteLine("3. Back to Main Menu");
                    Console.Write("Select an option: ");
                    var item = Console.ReadLine();

                    switch (item)
                    {
                        case "1":
                            AddStudent();
                            break;
                        case "2":
                            RemoveStudent();
                            break;
                        case "3":
                            return;
                        default:
                            Console.WriteLine("You have entered invalid item. Please try again.");
                            break;
                    }

              }
         }
            private void AddStudent()
            {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            Console.Write("Enter student age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter student class: ");
            string className = Console.ReadLine();

            Student newStudent = new Student(name, age, className);
            students.Add(newStudent);
            Console.WriteLine("The new student was added successfully!");
        }
        public void RemoveStudent()
        {
            Console.Write("Enter the name of the student to remove: ");
            string name = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.Name == name)
                {
                    students.Remove(student);
                    Console.WriteLine("Student removed successfully!");
                    return;
                }

                else
                {
                    throw new StudentNotFoundException("Student not found.");
                }
            }
        }
        public void ManageMarks()
        {
            Console.Write("Enter student name: ");
            var name = Console.ReadLine();
            var student = students.FirstOrDefault(s => s.Name == name);

            if (student != null)
            {
                while (true)
                {
                    Console.WriteLine("Manage Marks for " + student.Name);
                    Console.WriteLine("1. Add/Update Mark");
                    Console.WriteLine("2. Remove Mark");
                    Console.WriteLine("3. Back to Main Menu");
                    Console.Write("Select an option: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddOrUpdateMark(student);
                            break;
                        case "2":
                            RemoveMark(student);
                            break;
                        case "3":
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        private void AddOrUpdateMark(Student student)
        {
            Console.Write("Enter subject name: ");
            var subject = Console.ReadLine();
            Console.Write("Enter mark: ");
            var mark = int.Parse(Console.ReadLine());

            student.Marks[subject] = mark;
            Console.WriteLine("Mark added/updated successfully.");
        }

        private void RemoveMark(Student student)
        {
            Console.Write("Enter subject name to remove: ");
            var subject = Console.ReadLine();

            if (student.Marks.ContainsKey(subject))
            {
                student.Marks.Remove(subject);
                Console.WriteLine("Mark removed successfully.");
            }
            else
            {
                Console.WriteLine("Subject not found.");
            }
        }

        public void ViewInformation()
        {
            while (true)
            {
                Console.WriteLine("View Information");
                Console.WriteLine("1. View Student Details");
                Console.WriteLine("2. View Class Details");
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewStudentDetails();
                        break;
                    case "2":
                        ViewClassDetails();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void ViewStudentDetails()
        {
            Console.Write("Enter student name: ");
            var name = Console.ReadLine();
            var student = students.FirstOrDefault(s => s.Name == name);

            if (student != null)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Class: {student.Classname}, Average Mark: {student.AverageMark}");
                foreach (var mark in student.Marks)
                {
                    Console.WriteLine($"{mark.Key}: {mark.Value}");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        private void ViewClassDetails()
        {
            Console.Write("Enter class name: ");
            var className = Console.ReadLine();
            var classStudents = students.Where(s => s.Classname == className);

            if (classStudents.Any())
            {
                Console.WriteLine($"Class: {className}");
                foreach (var student in classStudents)
                {
                    Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Average Mark: {student.AverageMark}");
                }
            }
            else
            {
                Console.WriteLine("Class not found.");
            }
        }
    }
}
    
