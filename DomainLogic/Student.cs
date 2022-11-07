using System;

namespace DomainLogic
{
    public class Student
    {
        private string _name;

        private DateTime _dateOfBirth;

        public Student(string name, DateTime dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name),
                        "The name should not be empty");
            _name = name;

            //TODO: Homework - add the proper check for dateOfBirth
            _dateOfBirth = dateOfBirth;
        }

        public string Name
        {
            get => _name;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value),
                            "The name should not be empty");

                _name = value;
            }
        }

        public int Age => DateTime.Now.Year - _dateOfBirth.Year;
    }
}
