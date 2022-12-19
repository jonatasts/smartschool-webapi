namespace smartschool_webapi.Models
{
    public class Student
    {
        public Student() {}

        public Student(int id, string name, string lastName, string number)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
            this.Number = number;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
    }
}