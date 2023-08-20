using IssueTrackingSystem.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IssueTrackingSystem.Persistence.EntityTypeConfigurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);
        builder.Property(user => user.Login)
            .IsRequired();
        builder.HasIndex(user => user.Login)
            .IsUnique();
        builder.Property(user => user.Password)
            .IsRequired();
        builder.Property(user => user.Email)
            .IsRequired();
        builder.Property(user => user.Name)
            .IsRequired();

        builder.HasMany(user => user.RelatedProjects);
    }
}