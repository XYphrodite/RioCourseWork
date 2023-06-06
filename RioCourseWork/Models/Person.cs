using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

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
        public List<Record> Records = new();
    }
}
