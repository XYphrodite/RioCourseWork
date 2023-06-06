using System.Diagnostics.CodeAnalysis;

namespace RioCourseWork.Models
{
    public class Record
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        [AllowNull]
        public int RfIdKeyId { get; set; }
        [AllowNull]
        public RfIdKey RfIdKey { get; set; }
    }
}
