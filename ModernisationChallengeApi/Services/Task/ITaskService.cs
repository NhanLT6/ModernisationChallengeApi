using ModernisationChallengeApi.Dtos.TaskDtos;

namespace ModernisationChallengeApi.Services.Task;

public interface ITaskService
{
    public Task<List<Models.Task>> GetTasksAsync();

    public Task<Models.Task?> GetTaskAsync(int id);

    public Task<Models.Task> CreateTaskAsync(CreateTaskRequest task);

    public Task<Models.Task> UpdateTaskAsync(UpdateTaskRequest task);

    public Task<Models.Task> UpdateTaskStatusAsync(UpdateTaskStatusRequest task);

    public System.Threading.Tasks.Task DeleteTaskAsync(int id);
}
