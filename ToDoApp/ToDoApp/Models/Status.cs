namespace ToDoApp.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public ICollection<Duty>? Duties { get; set; }



    }
}