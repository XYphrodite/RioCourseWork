using System.ComponentModel.DataAnnotations;

namespace RioCourseWork.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public RfIdKey RfIdKey { get; set; } = new();
        public List<Record> Records { get; set; } = new();

        public string FullName() => Surname + " " + Name;
    }
}
