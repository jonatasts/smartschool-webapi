using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartschool_webapi.Models
{
    public class Discipline
    {
        public Discipline() {}

        public Discipline(int id, string name, int teacherId)
        {
            this.Id = id;
            this.Name = name;
            this.TeacherId = teacherId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}