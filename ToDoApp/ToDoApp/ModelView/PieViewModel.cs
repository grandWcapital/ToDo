using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoApp.Models;

namespace ToDoApp.ModelView
{
    public class PieViewModel
    {
        public IEnumerable<SelectListItem>? Categories { get; set; } = default!;
        public Duty Duty { get; set; }
    }
}
