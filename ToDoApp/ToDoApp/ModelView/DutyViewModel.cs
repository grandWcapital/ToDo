using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoApp.Models;

namespace ToDoApp.ModelView
{
    public class DutyViewModel
    {
        public IEnumerable<SelectListItem>? Categories { get; set; } = default!;
        public IEnumerable<SelectListItem>? Priorities { get; set; } = default!;
        public IEnumerable<SelectListItem>? Statuses { get; set; } = default!;
        public IEnumerable<SelectListItem>? Duties { get; set; } = default!;

        public Duty Duty { get; set; } = new Duty(); // ✅ Теперь `Duty` не будет null
    }

}
