using IssueTrackingSystem.Domain.Issues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IssueTrackingSystem.Persistence.EntityTypeConfigurations.Issues;

public class IssueConfiguration : IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.HasKey(issue => new { issue.ProjectId, issue.Index});
        builder.Property(issue => issue.Name).IsRequired();

        builder.HasOne(issue => issue.Author);
        builder.HasOne(issue => issue.Project);
        builder.HasOne(issue => issue.Assignee);
        
        builder.HasOne(issue => issue.Type);
        builder.HasOne(issue => issue.Priority);
        builder.HasOne(issue => issue.Status);
    }
}