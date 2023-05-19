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
        public DateTime Birthday { get; set; }
        //public int PositionId { get; set; }
        //public Position Position { get; set; }
        public List<Record> Records { get; set; } = new();
    }
}
