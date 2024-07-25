using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class Student
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public string Classname { get; set; }
        public Dictionary<string, int> Marks { get; set; } = new Dictionary<string, int>();

        public Student( string name, int age, string classname) 
        {
            Name = name;
            Age = age;
            Classname = classname;
        }
        public double AverageMark
        {
            get
            {
                return Marks.Count == 0 ? 0 : Marks.Values.Average();
            }
        }
    }
}

