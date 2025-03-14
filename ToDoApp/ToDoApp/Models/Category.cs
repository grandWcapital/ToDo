namespace ToDoApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Duty>? Duties { get; set; }
    }
}