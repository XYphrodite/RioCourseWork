using Microsoft.EntityFrameworkCore;
using RioCourseWork.Models;

namespace RioCourseWork.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> Persons;
        public DbSet<Record> Records;
        //public DbSet<Position> Positions;
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
