using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

//синтаксис события
/*[модификатор] event ИмяДелегата ИмяСобытия;*/

namespace Delegates_Events
{
    public delegate void ExamDelegate(string t);
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public static void FullName(Student student)
        {
            WriteLine($"{student.LastName}\t{student.FirstName}");
        }

        public void Exam(string task)
        {
            WriteLine($"Student {LastName} solved the {task}");
        }
    }

    class Teacher
    {
        public event ExamDelegate examEvent;
        public void Exam(string task)
        {
            examEvent(task);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> group = new List<Student>
            {
                new Student
                {
                    FirstName = "Barry",
                    LastName = "Allen",
                    BirthDate = new DateTime(1997,5,12)
                },
                new Student
                {
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    BirthDate = new DateTime(1977,11,23)
                },
                new Student
                {
                    FirstName = "Clark",
                    LastName = "Kent",
                    BirthDate = new DateTime(1023, 10,30)
                },
                new Student
                {
                    FirstName = "Petr",
                    LastName = "Kalashnikov",
                    BirthDate = new DateTime(1999, 12,31)
                },
                new Student
                {
                    FirstName = "Roman",
                    LastName = "Chankov",
                    BirthDate = new DateTime(1990, 2, 12)
                }
            };

            Teacher teacher = new Teacher();
            foreach (Student item in group)
            {
                teacher.examEvent += item.Exam;
            }

            WriteLine("Students of Justice League Academy: ");
            group.ForEach(Student.FullName);

            teacher.Exam("Examenation");

        }
    }
}
