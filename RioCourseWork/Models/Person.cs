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
        public List<RfIdKey> RfIdKeys { get; set; } = new();
        public List<Record> Records = new();
    }
}
