using ToDoApp.Models;

public interface IPriorityRepository
{
    Task<IEnumerable<Priority>> GetAllPriorities();

}