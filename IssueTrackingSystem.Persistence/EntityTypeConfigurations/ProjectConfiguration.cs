using IssueTrackingSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IssueTrackingSystem.Persistence.EntityTypeConfigurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(proj => proj.Id);
        builder.HasIndex(proj => proj.Id)
            .IsUnique();
        builder.Property(proj => proj.Name)
            .IsRequired();

        builder.HasMany(proj => proj.Collaborators);
        builder.HasMany(proj => proj.Issues);
    }
}