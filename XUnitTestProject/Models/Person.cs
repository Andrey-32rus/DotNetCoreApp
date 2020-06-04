using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject.Models
{
    public class Person : IEquatable<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }



        public bool Equals(Person person)
        {
            if (person == null)
                return false;

            var thisTuple = (Id, Name);
            var personTuple = (person.Id, person.Name);
            return thisTuple.Equals(personTuple); // using Tuples

            //person.Id == Id && person.Name == Name;    // or using traditional style
        }

        public override bool Equals(object obj)
        {
            var person = obj as Person;
            if (person == null)
                return false;

            return Equals(person);
        }

        public override int GetHashCode()
        {
            var thisTuple = (Id, Name);
            return thisTuple.GetHashCode();
        }


        //public static bool operator ==(Person p1, Person p2) =>
        //    (!object.ReferenceEquals(p1, null)) && p1.Equals(p2);

        //public static bool operator !=(Person p1, Person p2) =>
        //    !(p1 == p2);
    }
}
