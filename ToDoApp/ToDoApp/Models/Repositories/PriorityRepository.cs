
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models.Repositories
{
    public class PriorityRepository : IPriorityRepository
    {
        private readonly ToDoAppDbContext _context;
        public PriorityRepository(ToDoAppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Priority>> GetAllPriorities()
        {
            IQueryable<Priority> priorities = _context.Priorities.Select(x => x);
            return await priorities.AsNoTracking().ToListAsync();

        }
    }
}
