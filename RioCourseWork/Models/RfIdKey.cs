using System.Diagnostics.CodeAnalysis;

namespace RioCourseWork.Models
{
    public class RfIdKey
    {
        public int Id { get; set; }
        public string Value { get; set; } = string.Empty;
        [AllowNull]
        public Guid PersonId { get; set; }
        [AllowNull]
        public Person Person { get; set; }
    }
}
