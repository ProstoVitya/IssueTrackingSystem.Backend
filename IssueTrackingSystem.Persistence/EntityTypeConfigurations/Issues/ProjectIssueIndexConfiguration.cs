using IssueTrackingSystem.Domain;
using IssueTrackingSystem.Domain.Issues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IssueTrackingSystem.Persistence.EntityTypeConfigurations.Issues;

public class ProjectIssueIndexConfiguration : IEntityTypeConfiguration<ProjectIssueIndex>
{
    public void Configure(EntityTypeBuilder<ProjectIssueIndex> builder)
    {
        builder.HasNoKey();
        builder.HasOne<Project>();
    }
}