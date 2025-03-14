using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Utilities;
using ToDoApp.Models.Repositories;
using ToDoApp.Utilities;

namespace ToDoApp.Controllers
{
    public class DutyController : Controller
    {
        private readonly IDutyRepository _repository;
        public DutyController(IDutyRepository repository)
        {
            _repository = repository;
        }

        int PageSize = 5;
        public async Task<IActionResult> PagedIndex(int? pageNumeber)
        { var duties = await _repository.GetDutiesPaged(pageNumeber,PageSize);
            pageNumeber ??= 1;
            var count = await _repository.GetAllPiesCountAsync();

            return View( new PagedList<Duty>(duties.ToList(), pageNumeber.Value, count));
        }


        public async Task<IActionResult>Add (Duty duty)
        {

           return View();
        }
    }
}
