using AutoMapper;
using IssueTrackingSystem.Application.Commands.Issues.UpdateIssue;
using IssueTrackingSystem.Application.Common.Mappings;

namespace IssueTrackingSystem.WebApi.Models;

public class UpdateIssueDto : IMapWith<UpdateIssueCommand>
{
    public int IssueIndex { get; }
    public int ProjectId { get; }
    
    public string Name { get; }
    public string? Description { get; }
    public int StoryPoints { get; }
    public string? DevelopCommit { get; }
    public string? ReleaseCommit { get; }
    public DateOnly Started { get; }
    public DateOnly? Finished { get; }
    public DateOnly? FixBefore { get; }
    public int AssigneeId { get; }
    public int TypeId { get; }
    public int PriorityId { get; }
    public int StatusId { get; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateIssueCommand, UpdateIssueDto>();
    }
}