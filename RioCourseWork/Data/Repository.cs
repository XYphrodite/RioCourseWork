using Microsoft.EntityFrameworkCore;

namespace RioCourseWork.Data
{
    public class Repository
    {
        private DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }
    }
}
