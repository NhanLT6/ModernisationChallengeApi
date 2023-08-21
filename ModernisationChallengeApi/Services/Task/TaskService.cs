using Microsoft.EntityFrameworkCore;

using ModernisationChallengeApi.Data;
using ModernisationChallengeApi.Dtos.TaskDtos;

namespace ModernisationChallengeApi.Services.Task;

public class TaskService : ITaskService
{
    private readonly ModernisationChallengeContext _context;

    public TaskService(ModernisationChallengeContext context) => _context = context;

    public async Task<List<Models.Task>> GetTasksAsync() => await _context.Task.ToListAsync();

    public async Task<Models.Task?> GetTaskAsync(int id) => await _context.Task.FirstOrDefaultAsync(t => t.Id == id);

    public async Task<Models.Task> CreateTaskAsync(CreateTaskRequest task)
    {
        var newTask = new Models.Task
        {
            DateCreated = DateTime.Now,
            DateModified = DateTime.Now,
            DateDeleted = null,
            Completed = false,
            Details = task.Details
        };

        _context.Task.Add(newTask);
        await _context.SaveChangesAsync();

        return newTask;
    }

    public async Task<Models.Task> UpdateTaskAsync(UpdateTaskRequest task)
    {
        Models.Task? taskToUpdate = await _context.Task.FirstOrDefaultAsync(t => t.Id == task.Id);
        if (taskToUpdate is null)
        {
            throw new ArgumentException("Task not found");
        }

        taskToUpdate.Details = task.Details;

        await _context.SaveChangesAsync();

        return taskToUpdate;
    }

    public async Task<Models.Task> UpdateTaskStatusAsync(UpdateTaskStatusRequest task)
    {
        Models.Task? taskToUpdate = await _context.Task.FirstOrDefaultAsync(t => t.Id == task.Id);
        if (taskToUpdate is null)
        {
            throw new ArgumentException("Task not found");
        }

        taskToUpdate.Completed = task.Completed;

        await _context.SaveChangesAsync();

        return taskToUpdate;
    }

    public async System.Threading.Tasks.Task DeleteTaskAsync(int id)
    {
        Models.Task? taskToDelete = await _context.Task.FirstOrDefaultAsync(t => t.Id == id);
        if (taskToDelete is null)
        {
            throw new ArgumentException("Task not found");
        }

        _context.Task.Remove(taskToDelete);
        await _context.SaveChangesAsync();
    }
}
