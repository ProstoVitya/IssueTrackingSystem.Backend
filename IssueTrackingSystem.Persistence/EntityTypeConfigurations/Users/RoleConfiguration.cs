using IssueTrackingSystem.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IssueTrackingSystem.Persistence.EntityTypeConfigurations.Users;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(role => role.Id);
        builder.HasIndex(role => role.Id)
            .IsUnique();
        builder.Property(role => role.Name)
            .IsRequired();
    }
}