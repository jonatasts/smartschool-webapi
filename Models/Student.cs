using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartschool_webapi.Models
{
    public class Student
    {
        public Student() {}

        public Student(int id, string name, string lastName, int number)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
            this.Number = number;
        }

        public int Id { get; set; }
        public string ?Name { get; set; }
        public string ?LastName { get; set; }
        public int Number { get; set; }
    }
}