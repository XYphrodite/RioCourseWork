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
                .Include(k => k.Person)
                .FirstOrDefaultAsync(k => k.Value == rfId);
            if (key is null)
            {
                await _context.JournalItems.AddAsync(
                    new JournalItem
                    {
                        Time = DateTime.Now,
                        Value = rfId
                    });
                await _context.SaveChangesAsync();
            }
            else
            {
                var newRecord = new Record
                {
                    Time = DateTime.Now,
                    Person = key.Person
                };
                await _context.Records.AddAsync(newRecord);
                await _context.SaveChangesAsync();
                return newRecord;
            }
            return null;
        }
        public async Task<Person> GetPerson(int id) => await _context.Persons
            .Include(p => p.RfIdKey)
            .Include(p => p.Records)
            .FirstOrDefaultAsync(p => p.Id == id);
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
            return false;
        }

        internal async Task<List<Record>> GetRecords() => await _context.Records
            .Include(r => r.Person)
            .ToListAsync();

        internal async Task<List<JournalItem>> GetJournalItems() => await _context.JournalItems.ToListAsync();

        internal async Task DeleteJournalItem(int id)
        {
            var item = await _context.JournalItems.FindAsync(id);
            if (item is not null)
            {
                _context.JournalItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        internal async Task UpdatePerson(Person person)
        {
            var model = await _context.Persons.FindAsync(person.Id);
            model.Name = person.Name;
            model.Surname = person.Surname;
            await _context.SaveChangesAsync();
        }
    }
}
