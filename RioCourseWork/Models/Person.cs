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
        public List<Record> Records { get; set; } = new();
    }
}
