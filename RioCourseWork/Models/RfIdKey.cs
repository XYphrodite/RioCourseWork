namespace RioCourseWork.Models
{
    public class RfIdKey
    {
        public int Id { get; set; }
        public string Value { get; set; } = string.Empty;
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public List<Record> Records { get; set; } = new();
    }
}
