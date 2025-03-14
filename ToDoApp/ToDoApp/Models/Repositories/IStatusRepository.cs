namespace ToDoApp.Models.Repositories
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetAllStatuses();

    }
}
