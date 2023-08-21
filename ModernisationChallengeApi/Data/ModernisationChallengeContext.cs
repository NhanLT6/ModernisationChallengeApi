using Microsoft.EntityFrameworkCore;

using Task = ModernisationChallengeApi.Models.Task;

namespace ModernisationChallengeApi.Data;

public class ModernisationChallengeContext : DbContext
{
    public ModernisationChallengeContext(DbContextOptions<ModernisationChallengeContext> options)
        : base(options) { }

    public DbSet<Task> Task { get; set; } = default!;
}
