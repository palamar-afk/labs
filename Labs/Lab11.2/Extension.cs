using System;
using System.Collections.Generic;

namespace Lab11_2
{
    static class Extension
    {
        public static List<Student> FindStudent(this List<Student> students, Student.StudentPredicateDelegate findStudentDelegate)
        {
            List<Student> resultList = new List<Student>();
            foreach (var student in students)
            {
                if (findStudentDelegate(student))
                {
                    resultList.Add(student);
                }
            }
            return resultList;
        }
        public static void show(this Student student)
        {
            Console.WriteLine($"Возраст {student.Age}, Имя: {student.FirstName}, Фамилия: {student.LastName}");
        }
    }
}