
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models.Repositories
{
    public class DutyRepository : IDutyRepository
    {
      
        private   readonly ToDoAppDbContext toDoAppDbContext; 
        public DutyRepository (ToDoAppDbContext toDoAppDbContext)
        {
            this.toDoAppDbContext = toDoAppDbContext;
        }
        public async Task<int> Add(Duty duty)
        {
            toDoAppDbContext.Duties.AddAsync(duty);
            return await toDoAppDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Duty>> GetDuties()

        {
            var duties = await toDoAppDbContext.Duties.Select(x => x).ToListAsync();
            return duties;
        }
    }
}
