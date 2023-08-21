namespace ModernisationChallengeApi.Dtos.TaskDtos;

public class TaskResponse
{
    public int Id { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    public DateTime? DateDeleted { get; set; }

    public bool Completed { get; set; }

    public string Details { get; set; } = string.Empty;
}