using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Task = ModernisationChallengeApi.Models.Task;

namespace ModernisationChallengeApi.ModelConfigs;

public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.ToTable("Tasks");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id).IsRequired();
        builder.Property(t => t.DateCreated).IsRequired();
        builder.Property(t => t.DateModified).IsRequired();
        builder.Property(t => t.DateDeleted).IsRequired(false);
        builder.Property(t => t.Completed).IsRequired();
        builder.Property(t => t.Details).IsRequired();
    }
}
