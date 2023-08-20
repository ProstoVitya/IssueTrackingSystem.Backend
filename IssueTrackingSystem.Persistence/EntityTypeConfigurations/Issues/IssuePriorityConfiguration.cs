using IssueTrackingSystem.Domain.Issues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IssueTrackingSystem.Persistence.EntityTypeConfigurations.Issues;

public class IssuePriorityConfiguration : IEntityTypeConfiguration<IssuePriority>
{
    public void Configure(EntityTypeBuilder<IssuePriority> builder)
    {
        builder.HasKey(issuePriority => issuePriority.Id);
        builder.HasIndex(issuePriority => issuePriority.Id).IsUnique();
        builder.Property(issuePriority => issuePriority.Name).IsRequired();
    }
}