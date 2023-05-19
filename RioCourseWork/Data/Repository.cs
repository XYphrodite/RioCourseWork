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
    }
}
