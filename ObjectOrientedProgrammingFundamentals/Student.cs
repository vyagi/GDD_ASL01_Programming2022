using System;

namespace ObjectOrientedProgrammingFundamentals
{
    class Student
    {
        private string _name;
        private DateTime _dateOfBirth;

        public Student(string fullName, DateTime dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentNullException(nameof(fullName), "Name should be valid");
                        
            _name = fullName;

            if (true) //some checks for birthdate - your homework
            {

            }
            _dateOfBirth = dateOfBirth;
        }

        //public int GetAge()  // Don't do it, it's not the Java world
        //{
        //    return _age;
        //}

        //public void SetAge(int newAge)
        //{
        //    if (newAge < 1 || newAge > 100)
        //        throw new ArgumentOutOfRangeException(nameof(newAge), "Age shoud be from 1 to 100");

        //    _age = newAge;
        //}

        public int Age => DateTime.Now.Year - _dateOfBirth.Year;

        //As a homework, provide the properties for name
    }
}
