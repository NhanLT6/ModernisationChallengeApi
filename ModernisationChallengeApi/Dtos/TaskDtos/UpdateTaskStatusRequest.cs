namespace ModernisationChallengeApi.Dtos.TaskDtos;

public class UpdateTaskStatusRequest
{
    public int Id { get; set; }

    public bool Completed { get; set; }
}