using ModernisationChallengeApi.Dtos.TaskDtos;

namespace ModernisationChallengeApi.Services.Task;

public interface ITaskService
{
    public Task<List<Models.Task>> GetTasksAsync();

    public Task<Models.Task?> GetTaskAsync(int id);

    public Task<Models.Task> CreateTaskAsync(UpsertTaskRequest task);

    public Task<Models.Task> UpdateTaskAsync(int id, UpsertTaskRequest task);

    public Task<Models.Task> UpdateTaskCompleteStatusAsync(int id, bool isCompleted);

    public System.Threading.Tasks.Task DeleteTaskAsync(int id);
}
