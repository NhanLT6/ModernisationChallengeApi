using ModernisationChallengeApi.Dtos.TaskDtos;
using ModernisationChallengeApi.Models;

namespace ModernisationChallengeApi.Services.Task;

public interface ITaskService
{
    public Task<List<Models.Task>> GetTasksAsync(Paging paging);

    public Task<Models.Task?> GetTaskAsync(int id);

    public Task<Models.Task> CreateTaskAsync(UpsertTaskRequest task);

    public Task<Models.Task> UpdateTaskAsync(int id, UpsertTaskRequest task);

    public Task<Models.Task> UpdateTaskCompleteStatusAsync(int id, bool isCompleted);

    public System.Threading.Tasks.Task DeleteTaskAsync(int id);
}
