﻿using IssueTrackingSystem.Application.Queries.IssuePriorities.GetIssuePriorityDetails;
using IssueTrackingSystem.Application.Queries.IssueStatuses.GetIssueStatusDetails;
using IssueTrackingSystem.Application.Queries.IssueTypes.GetIssueTypeDetails;
using IssueTrackingSystem.Application.Queries.Projects.GetProject;
using IssueTrackingSystem.Application.Queries.Users.GetUserDetails;
using IssueTrackingSystem.Domain;
using IssueTrackingSystem.Domain.Issues;
using IssueTrackingSystem.Domain.Users;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.Issues;

internal class IssueRelatedInfoDao
{
    private readonly IMediator _mediator;

    public IssueRelatedInfoDao(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<User> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var userRequest = new GetUserDetailsQuery
        {
            UserId = userId
        };
        var user = await _mediator.Send(userRequest, cancellationToken);
        return user;
    }

    public async Task<IssueType> GetIssueTypeByIdAsync(int typeId, CancellationToken cancellationToken)
    {
        var issueTypeRequest = new GetIssueTypeDetailsQuery
        {
            IssueTypeId = typeId
        };
        var issueType = await _mediator.Send(issueTypeRequest, cancellationToken);
        return issueType;
    }

    public async Task<IssuePriority> GetIssuePriorityByIdAsync(int priorityId, CancellationToken cancellationToken)
    {
        var priorityRequest = new GetIssuePriorityDetailsQuery
        {
            IssuePriorityId = priorityId
        };

        var priority = await _mediator.Send(priorityRequest, cancellationToken);
        return priority;
    }

    public async Task<IssueStatus> GetIssueStatusByIdAsync(int statusId, CancellationToken cancellationToken)
    {
        var statusRequest = new GetIssueStatusDetailsQuery
        {
            IssueStatusId = statusId
        };

        var status = await _mediator.Send(statusRequest, cancellationToken);
        return status;
    }

    public async Task<Project> GetIssueProjectByIdAsync(int projectId, CancellationToken cancellationToken)
    {
        var projectRequest = new GetProjectQuery
        {
            ProjectId = projectId
        };

        var project = await _mediator.Send(projectRequest, cancellationToken);
        return project;
    }
}