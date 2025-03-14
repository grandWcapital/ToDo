
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ToDoAppDbContext _context;
        public StatusRepository(ToDoAppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Status>> GetAllStatuses()
        {
           IQueryable<Status> statuses = _context.Statuses.Select(x => x);
            return await statuses.AsNoTracking().ToListAsync();
        }
    }
}
