namespace ToDoApp.Models.Repositories
{
    public interface IDutyRepository
    {
        Task<int> GetAllPiesCountAsync();
       Task<IEnumerable<Duty>> GetDutiesPaged(int? PageNumber, int PageSize);
       
        Task<int> Add(Duty duty);
    }
}
