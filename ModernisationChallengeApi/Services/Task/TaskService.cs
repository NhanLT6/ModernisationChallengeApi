using Microsoft.EntityFrameworkCore;

using ModernisationChallengeApi.Data;
using ModernisationChallengeApi.Dtos.TaskDtos;
using ModernisationChallengeApi.Models;

namespace ModernisationChallengeApi.Services.Task;

public class TaskService : ITaskService
{
    private readonly ModernisationChallengeContext _context;

    public TaskService(ModernisationChallengeContext context) => _context = context;

    public async Task<List<Models.Task>> GetTasksAsync(Paging paging)
    {
        // No paging, return whole list of Tasks
        if (paging.PageSize == -1) return await _context.Tasks.ToListAsync();

        // Paging if needed
        List<Models.Task> pagedTasks = await _context.Tasks
            .Skip(paging.PageIndex * paging.PageSize)
            .Take(paging.PageSize)
            .ToListAsync();

        return pagedTasks;
    }

    public async Task<Models.Task?> GetTaskAsync(int id) => await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

    public async Task<Models.Task> CreateTaskAsync(UpsertTaskRequest task)
    {
        DateTime now = DateTime.Now;

        var newTask = new Models.Task
        {
            DateCreated = now,
            DateModified = now,
            DateDeleted = null,
            Completed = false,
            Details = task.Details
        };

        _context.Tasks.Add(newTask);
        await _context.SaveChangesAsync();

        return newTask;
    }

    public async Task<Models.Task> UpdateTaskAsync(int id, UpsertTaskRequest task)
    {
        Models.Task? taskToUpdate = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if (taskToUpdate is null) throw new ArgumentException("Task not found");

        taskToUpdate.Details = task.Details;
        taskToUpdate.DateModified = DateTime.Now;

        await _context.SaveChangesAsync();

        return taskToUpdate;
    }

    public async Task<Models.Task> UpdateTaskCompleteStatusAsync(int id, bool isCompleted)
    {
        Models.Task? taskToUpdate = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if (taskToUpdate is null) throw new ArgumentException("Task not found");

        taskToUpdate.Completed = isCompleted;
        taskToUpdate.DateModified = DateTime.Now;

        await _context.SaveChangesAsync();

        return taskToUpdate;
    }

    public async System.Threading.Tasks.Task DeleteTaskAsync(int id)
    {
        Models.Task? taskToDelete = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if (taskToDelete is null) throw new ArgumentException("Task not found");

        taskToDelete.DateDeleted = DateTime.Now;
        await _context.SaveChangesAsync();
    }
}
