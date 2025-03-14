using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Utilities;
using ToDoApp.Models.Repositories;
using ToDoApp.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoApp.ModelView;

namespace ToDoApp.Controllers
{
    public class DutyController : Controller
    {
        private readonly IDutyRepository _dutyrepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPriorityRepository _priorityRepository;
        private readonly IStatusRepository _statusRepository;
      
        public DutyController(IDutyRepository repository, ICategoryRepository categoryRepository, IPriorityRepository priorityRepository, IStatusRepository statusRepository)
        {
            _dutyrepository = repository;
            _categoryRepository = categoryRepository;
            _priorityRepository = priorityRepository;
            _statusRepository = statusRepository;
        }
        int PageSize = 5;
        public async Task<IActionResult> PagedIndex(int? pageNumeber)
        { var duties = await _dutyrepository.GetDutiesPaged(pageNumeber,PageSize);
            pageNumeber ??= 1;
            var count = await _dutyrepository.GetAllPiesCountAsync();

            return View( new PagedList<Duty>(duties.ToList(), pageNumeber.Value, count));
        }


        public async Task<IActionResult>Add ()
        {
            try
            {
                IEnumerable<Category>? categories = await _categoryRepository.GetCategories();
                IEnumerable<SelectListItem> selectListItems = new SelectList(categories, "Id", "Name", null);
                DutyViewModel duties = new DutyViewModel
                {
                    Categories = selectListItems,

                };
                return View(duties);

            }
            catch(Exception ex)
           
            {
                ViewData["ErrorMessage"] = $"An error occurred while processing your request:{ex}";
            }

            return View(new DutyViewModel() );
        }

        [HttpPost]
        public async Task<IActionResult> Add(DutyViewModel dutyViewModel)
        {
            Duty duty = new()
            {
                CategoryId = dutyViewModel?.Duty?.CategoryId,
                Title = dutyViewModel?.Duty?.Title ?? string.Empty,
                Description = dutyViewModel?.Duty?.Description ?? string.Empty,
                Priority = dutyViewModel?.Duty?.Priority,
                Status = dutyViewModel?.Duty?.Status,
                Duration = dutyViewModel?.Duty?.Duration,
                DueDate = dutyViewModel?.Duty?.DueDate ?? DateTime.Now
            };
            await _dutyrepository.Add(duty);
            return RedirectToAction(nameof(Index));
        }
    }
}
