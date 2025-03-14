
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models.Repositories
{
    public class DutyRepository : IDutyRepository
    {
        private readonly ToDoAppDbContext _dbContext;
        public DutyRepository(ToDoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Add(Duty duty)
        {
           _dbContext.Add(duty);
            return  await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetAllPiesCountAsync()
        {
           return await _dbContext.Duties.CountAsync();
        }

        public async Task<IEnumerable<Duty>> GetDutiesPaged(int? PageNumber, int PageSize)
        {
            IQueryable<Duty> duties = _dbContext.Duties.Select(x=>x) ;
            PageNumber ??= 1;

            duties = duties.Skip((PageNumber.Value - 1) * PageSize).Take(PageSize);    
            return await duties.AsNoTracking().ToListAsync();
        }
    }
}
