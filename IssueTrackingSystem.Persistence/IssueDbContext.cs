using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain;
using IssueTrackingSystem.Domain.Issues;
using IssueTrackingSystem.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingSystem.Persistence;

public class IssueDbContext : DbContext, IIssueDbContext
{
    public IssueDbContext(DbContextOptions<IssueDbContext> options) : base(options) { }
    
    public DbSet<Issue> Issues { get; set; }
    public DbSet<IssuePriority> IssuePriorities { get; set; }
    public DbSet<IssueStatus> IssueStatuses { get; set; }
    public DbSet<IssueType> IssueTypes { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Rights> Rights { get; set; }
    public DbSet<ProjectIssueIndex> ProjectIssueIndexes { get; set; }
}