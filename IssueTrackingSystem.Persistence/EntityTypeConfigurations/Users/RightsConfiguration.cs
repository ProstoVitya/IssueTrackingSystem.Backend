using IssueTrackingSystem.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IssueTrackingSystem.Persistence.EntityTypeConfigurations.Users;

public class RightsConfiguration : IEntityTypeConfiguration<Rights>
{
    public void Configure(EntityTypeBuilder<Rights> builder)
    {
        builder.HasKey(right => right.Id);
        builder.HasIndex(right => right.Id)
            .IsUnique();
    }
}