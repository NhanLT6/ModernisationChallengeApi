using Microsoft.AspNetCore.Mvc;

using ModernisationChallengeApi.Dtos.TaskDtos;
using ModernisationChallengeApi.Services.Task;

using Task = ModernisationChallengeApi.Models.Task;

namespace ModernisationChallengeApi.Controllers;

[Route("api/tasks")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService) => _taskService = taskService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Task>>> GetTasks()
    {
        List<Task> tasks = await _taskService.GetTasksAsync();

        return Ok(tasks);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Task>> GetTask(int id)
    {
        Task? task = await _taskService.GetTaskAsync(id);
        if (task is null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTask(UpdateTaskRequest request)
    {
        Task? task = await _taskService.GetTaskAsync(request.Id);
        if (task is null)
        {
            return NotFound();
        }

        Task<Task> updatedTask = _taskService.UpdateTaskAsync(request);

        return Ok(updatedTask);
    }

    [HttpPut("{id:int}/status")]
    public async Task<IActionResult> UpdateTaskStatus(UpdateTaskStatusRequest request, int id)
    {
        Task? task = await _taskService.GetTaskAsync(request.Id);
        if (task is null)
        {
            return NotFound();
        }

        Task<Task> updatedTask = _taskService.UpdateTaskStatusAsync(request);

        return Ok(updatedTask);
    }

    [HttpPost]
    public async Task<ActionResult<Task>> CreateTask(CreateTaskRequest request)
    {
        Task task = await _taskService.CreateTaskAsync(request);

        return Ok(task);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        Task? task = await _taskService.GetTaskAsync(id);
        if (task is null)
        {
            return NotFound();
        }

        await _taskService.DeleteTaskAsync(id);

        return Ok();
    }
}
