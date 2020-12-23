namespace Lab11_2
{
    class Student
    {
        public delegate bool StudentPredicateDelegate(Student student);
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public static bool AgeMore_18(Student student)
        {
            if (student.Age >= 18) return true;
            else return false;
        }
        public static bool FirstName_A(Student student)
        {
            if (student.FirstName[0] == 'A') return true;
            else return false;
        }
        public static bool LastNameIsMore_3(Student student)
        {
            if (student.LastName.Length > 3) return true;
            else return false;
        }
    }

}