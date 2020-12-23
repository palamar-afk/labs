using System;
using System.Collections.Generic;

namespace Lab11_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int countOfStudents = 12;
            Random rand = new Random();
            for (int i = 0; i < countOfStudents; i++)
            {
                students.Add(new Student()
                {
                    Age = rand.Next(16, 28),
                    FirstName = RandomName(rand),
                    LastName = RandomLastName(rand)
                });
            }

            Console.WriteLine("Старше 18 лет:");
            foreach (var student in students.FindStudent(Student.AgeMore_18))
                student.show();

            Console.WriteLine(new string('=', 60));

            Console.WriteLine("Имя начинается на букву \"А\" :");
            foreach (var student in students.FindStudent(Student.FirstName_A))
                student.show();

            Console.WriteLine(new string('=', 60));

            Console.WriteLine("Фамилия больше 3 букв:");
            foreach (var student in students.FindStudent(Student.LastNameIsMore_3))
                student.show();

            Console.WriteLine(new string('=', 60));

            //реализация через анонимные методы
            Console.WriteLine("Старше 18 лет:");
            foreach (var student in students.FindStudent(x => x.Age >= 18))
                student.show();

            Console.WriteLine(new string('=', 60));

            Console.WriteLine("Имя начинается на букву \"А\" :");
            foreach (var student in students.FindStudent(x => x.FirstName[0] == 'A'))
                student.show();

            Console.WriteLine(new string('=', 60));

            Console.WriteLine("Фамилия больше 3 букв:");
            foreach (var student in students.FindStudent(x => x.LastName.Length > 3))
                student.show();

            Console.WriteLine(new string('=', 60));

            Console.WriteLine("Старше 20 лет и младше 25:");
            foreach (var student in students.FindStudent(x => x.Age >= 20 && x.Age < 25))
                student.show();

            Console.WriteLine(new string('=', 60));

            Console.WriteLine("Имя \"Andrew\" :");
            foreach (var student in students.FindStudent(x => x.FirstName == "Andrew"))
                student.show();

            Console.WriteLine(new string('=', 60));

            Console.WriteLine("Фамилия \"Troelsen\":");
            foreach (var student in students.FindStudent(x => x.LastName == "Troelsen"))
                student.show();

        }
        private static string RandomName(Random rand)
        {
            string[] names = {
        "Mike",
        "Jonh",
        "Andrew",
        "Jane",
        "Michael",
        "Max",
        "Pavel",
        "Misha",
        "Igor",
        "Alex"
      };
            return names[rand.Next(0, 10)];
        }
        private static string RandomLastName(Random rand)
        {
            string[] last_names = {
        "Jy",
        "Al",
        "Messi",
        "Ronaldo",
        "Troelsen",
        "Skidan",
        "Samoylov",
        "Petrenko"
      };
            return last_names[rand.Next(0, last_names.Length)];
        }
    }
}