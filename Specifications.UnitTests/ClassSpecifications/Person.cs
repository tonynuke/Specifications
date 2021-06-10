using System;

namespace Specifications.UnitTests.ClassSpecifications
{
    public class Person
    {
        public Person(string name, string hometown, DateTime birthDate)
        {
            Name = name;
            Hometown = hometown;
            BirthDate = birthDate;
        }

        public string Name { get; }

        public string Hometown { get; }

        public DateTime BirthDate { get; }
    }
}