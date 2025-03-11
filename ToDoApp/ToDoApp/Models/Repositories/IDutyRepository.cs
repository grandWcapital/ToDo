namespace ToDoApp.Models.Repositories
{
    public interface IDutyRepository
    {
       Task<IEnumerable<Duty>> GetDuties();
       Task<int> Add(Duty duty);
    }
}
