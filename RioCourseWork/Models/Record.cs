namespace RioCourseWork.Models
{
    public class Record
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int RfIdKeyId { get; set; }
        public RfIdKey RfIdKey { get; set; }
    }
}
