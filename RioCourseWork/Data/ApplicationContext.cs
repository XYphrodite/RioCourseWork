using Microsoft.EntityFrameworkCore;
using RioCourseWork.Models;

namespace RioCourseWork.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<RfIdKey> RfIdKeys { get; set; }
        public DbSet<JournalItem> JournalItems { get; set; }
        //public DbSet<Position> Positions;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
