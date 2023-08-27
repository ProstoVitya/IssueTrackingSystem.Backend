﻿using IssueTrackingSystem.Domain;
using IssueTrackingSystem.Domain.Issues;
using IssueTrackingSystem.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IssueTrackingSystem.Application.Interfaces;

public interface IIssueDbContext
{
    DbSet<Issue> Issues { get; set; }
    DbSet<IssuePriority> IssuePriorities { get; set; }
    DbSet<IssueStatus> IssueStatuses { get; set; }
    DbSet<IssueType> IssueTypes { get; set; }
    DbSet<Project> Projects { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<User> Users { get; set; }
    public DbSet<Rights> Rights { get; set; }
    public DbSet<ProjectIssueIndex> ProjectIssueIndexes { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
}