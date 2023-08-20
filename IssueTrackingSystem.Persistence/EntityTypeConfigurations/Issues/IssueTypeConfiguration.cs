using IssueTrackingSystem.Domain.Issues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IssueTrackingSystem.Persistence.EntityTypeConfigurations.Issues;

public class IssueTypeConfiguration : IEntityTypeConfiguration<IssueType>
{
    public void Configure(EntityTypeBuilder<IssueType> builder)
    {
        builder.HasKey(issueType => issueType.Id);
        builder.HasIndex(issueType => issueType.Id).IsUnique();
        builder.Property(issueType => issueType.Name).IsRequired();
    }
}