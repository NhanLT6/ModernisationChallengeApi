namespace ModernisationChallengeApi.Models;

public class BaseEntity<T> where T : IEquatable<T>, IComparable<T>
{
    public T Id { get; set; } = default!;

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    public DateTime? DateDeleted { get; set; }
}
