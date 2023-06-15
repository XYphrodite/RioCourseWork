using System.ComponentModel.DataAnnotations;

namespace RioCourseWork.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public RfIdKey RfIdKey { get; set; } = new();
        public List<Record> Records { get; set; } = new();

        public string FullName() => Surname + " " + Name;
    }
}
