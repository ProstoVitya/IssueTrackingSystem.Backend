using IssueTrackingSystem.Domain.Issues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IssueTrackingSystem.Persistence.EntityTypeConfigurations.Issues;

public class IssueStatusConfiguration : IEntityTypeConfiguration<IssueStatus>
{
    public void Configure(EntityTypeBuilder<IssueStatus> builder)
    {
        builder.HasKey(issueStatus => issueStatus.Id);
        builder.HasIndex(issueStatus => issueStatus.Id).IsUnique();
        builder.Property(issueStatus => issueStatus.Name).IsRequired();
    }
}