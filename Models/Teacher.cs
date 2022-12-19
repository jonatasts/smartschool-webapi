using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartschool_webapi.Models
{
    public class Teacher
    {
        public Teacher() {}

        public Teacher(int id, string name, string discipline)
        {
            this.Id = id;
            this.Name = name;
            this.Discipline = discipline;
        }

        public int Id { get; set; }
        public string ?Name { get; set; }
        public string ?Discipline { get; set; }
    }
}