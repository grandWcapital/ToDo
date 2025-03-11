using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Models.Repositories;

namespace ToDoApp.Controllers
{
    public class DutyController : Controller
    {
        private readonly IDutyRepository dutyRepository;
        public DutyController(IDutyRepository dutyRepository)
        {
            this.dutyRepository = dutyRepository;
        }
        public async Task<IActionResult> Index()
        {
            var duties = await dutyRepository.GetDuties();
            return View(duties);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Duty duty)
        { 
            var newduty = await dutyRepository.Add(duty);
            return RedirectToAction("Index");
        }

    }
}
