using Microsoft.EntityFrameworkCore;
using RioCourseWork.Models;
using static RioCourseWork.Models.Record;

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
        public async Task<Record> AddRecord(string rfId)
        {
            var key = await _context.RfIdKeys
                .FirstOrDefaultAsync(k => k.Value == rfId);
            if (key is null)
                key = await AddKey(rfId);
            var newRecord = new Record
            {
                RfIdKey = key,
                Time = DateTime.Now,
            };
            await _context.Records.AddAsync(newRecord);
            await _context.SaveChangesAsync();
            return newRecord;
        }
        public async Task<Person> GetPerson(int id) => await _context.Persons.FindAsync(id);
        public async Task CreatePerson(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }
        internal async Task DeletePerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
        internal async Task<RfIdKey> AddKey(string key)
        {
            var model = new RfIdKey
            {
                Value = key
            };
            await _context.RfIdKeys.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        internal async Task<bool> CheckKey(string rfId)
        {
            await AddRecord(rfId);
            var key = await _context.RfIdKeys.Include(k => k.Person)
                .FirstOrDefaultAsync(k => k.Value == rfId);
            if (key is not null)
                if (key.Person is not null) return true;
            return true;
        }

        internal async Task<List<Record>> GetRecords() => await _context.Records
            .Include(r => r.RfIdKey.Person)
            .ToListAsync();
    }
}
