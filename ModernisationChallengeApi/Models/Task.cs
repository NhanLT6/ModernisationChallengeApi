namespace ModernisationChallengeApi.Models;

public class Task : BaseEntity<int>
{
    public bool Completed { get; set; }

    public string Details { get; set; } = string.Empty;
}
