using Microsoft.EntityFrameworkCore;
using RioCourseWork.Models;

namespace RioCourseWork.Data
{
    public class Repository
    {
        private ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Person>> GetPersons() => await _context.Persons.ToListAsync();
        public async Task AddRecord(Record model)
        {
            await _context.Records.AddAsync(model);
            await _context.SaveChangesAsync();
        }
        public async Task<Person> GetPersons(int id) => await _context.Persons.FindAsync(id);
        public async Task CreatePerson(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }
    }
}
