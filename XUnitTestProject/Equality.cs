using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUnitTestProject.Models;

namespace XUnitTestProject
{
    public class Equality
    {
        [Fact]
        public void Main()
        {
            var person1 = new Person { Id = 1, Name = "Eric" };
            var person2 = new Person { Id = 1, Name = "Eric" };

            var personList = new List<Person> { person1 };
            var personDictionary = new Dictionary<Person, int> { { person1, 1 } };

            bool equals = person1.Equals(person2);
            bool contains = personList.Contains(person2);
            bool containsKey = personDictionary.ContainsKey(person2);
            bool hashEquality = person1.GetHashCode() == person2.GetHashCode();
        }
    }
}
