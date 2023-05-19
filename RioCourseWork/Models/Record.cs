namespace RioCourseWork.Models
{
    public class Record
    {
        public int Id { get; set; }
        public string RFID { get; set; }
        public DateTime Time { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
