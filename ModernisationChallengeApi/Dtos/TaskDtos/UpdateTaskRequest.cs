namespace ModernisationChallengeApi.Dtos.TaskDtos;

public class UpdateTaskRequest
{
    public int Id { get; set; }

    public string Details { get; set; } = string.Empty;
}