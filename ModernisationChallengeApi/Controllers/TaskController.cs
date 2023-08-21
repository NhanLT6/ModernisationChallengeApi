using AutoMapper;

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

    private readonly IMapper _mapper;

    public TaskController(ITaskService taskService, IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskResponse>>> GetTasks()
    {
        List<Task> tasks = await _taskService.GetTasksAsync();
        var taskResponses = _mapper.Map<IEnumerable<TaskResponse>>(tasks);

        return Ok(taskResponses);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TaskResponse>> GetTask(int id)
    {
        Task? task = await _taskService.GetTaskAsync(id);
        if (task is null) return NotFound();

        var taskResponse = _mapper.Map<TaskResponse>(task);

        return Ok(taskResponse);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<TaskResponse>> UpdateTask(int id, UpsertTaskRequest request)
    {
        Task? task = await _taskService.GetTaskAsync(id);
        if (task is null) return NotFound();

        Task updatedTask = await _taskService.UpdateTaskAsync(id, request);
        var taskResponse = _mapper.Map<TaskResponse>(updatedTask);

        return Ok(taskResponse);
    }

    [HttpPut("{id:int}/status")]
    public async Task<ActionResult<TaskResponse>> UpdateTaskStatus(int id, bool isCompleted)
    {
        Task? task = await _taskService.GetTaskAsync(id);
        if (task is null) return NotFound();

        Task updatedTask = await _taskService.UpdateTaskCompleteStatusAsync(id, isCompleted);
        var taskResponse = _mapper.Map<TaskResponse>(updatedTask);

        return Ok(taskResponse);
    }

    [HttpPost]
    public async Task<ActionResult<TaskResponse>> CreateTask(UpsertTaskRequest request)
    {
        Task task = await _taskService.CreateTaskAsync(request);
        var taskResponse = _mapper.Map<TaskResponse>(task);

        return Ok(taskResponse);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        Task? task = await _taskService.GetTaskAsync(id);
        if (task is null) return NotFound();

        await _taskService.DeleteTaskAsync(id);

        return Ok();
    }
}
