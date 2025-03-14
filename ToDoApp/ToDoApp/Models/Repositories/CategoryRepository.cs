
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {   private readonly ToDoAppDbContext _context;
        public CategoryRepository(ToDoAppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {IQueryable<Category> categories = _context.Categories.Select(x => x);

            return await categories.AsNoTracking().ToListAsync();
        }
    }
}
