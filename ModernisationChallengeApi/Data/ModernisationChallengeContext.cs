using Microsoft.EntityFrameworkCore;

using ModernisationChallengeApi.Models;

using Task = ModernisationChallengeApi.Models.Task;

namespace ModernisationChallengeApi.Data;

public class ModernisationChallengeContext : DbContext
{
    public ModernisationChallengeContext(DbContextOptions<ModernisationChallengeContext> options)
        : base(options) { }

    public DbSet<Task> Tasks { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Filter out deleted tasks (Soft delete)
        modelBuilder.Entity<Task>().HasQueryFilter(t => t.DateDeleted == null);
    }
}
