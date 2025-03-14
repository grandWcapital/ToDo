namespace ToDoApp.Models
{
    public class Priority
    {
        public int PriorityId { get; set; }
        public string Name { get; set; }
        public ICollection<Duty>? Duties { get; set; }
    }
   
}