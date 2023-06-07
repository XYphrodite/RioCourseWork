using System.Diagnostics.CodeAnalysis;

namespace RioCourseWork.Models
{
    public class Record
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public Type type { get; set; }

        public enum Type : byte
        {
            Key,
            Camera
        }
    }
}
