using AutoMapper;
using IssueTrackingSystem.Application.Commands.Issues.CreateIssue;
using IssueTrackingSystem.Application.Commands.Issues.DeleteIssue;
using IssueTrackingSystem.Application.Commands.Issues.UpdateIssue;
using IssueTrackingSystem.Application.Queries.Issues.GetIssueDetails;
using IssueTrackingSystem.Application.Queries.Issues.GetIssueList;
using IssueTrackingSystem.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace IssueTrackingSystem.WebApi.Controllers;

[Route("api/[controller]")]
public class IssueController : BaseController
{
    private readonly IMapper _mapper;

    public IssueController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IssueListVm>> GetAll()
    {
        var query = new GetIssueListQuery
        {
            AssigneeId = UserId
        };
        
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpGet("{projectId:int}/{issueIndex:int}")]
    public async Task<ActionResult<IssueDetailsDto>> Get([FromQuery] int projectId, [FromQuery] int issueIndex)
    {
        var query = new GetIssueDetailsQuery()
        {
            ProjectId = projectId,
            IssueIndex = issueIndex
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateIssueDto createIssueDto)
    {
        var command = _mapper.Map<CreateIssueCommand>(createIssueDto);
        command.AuthorId = UserId;
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateIssueDto updateIssueDto)
    {
        var command = _mapper.Map<UpdateIssueCommand>(updateIssueDto);
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] int projectId, int issueIndex)
    {
        var command = new DeleteIssueCommand
        {
            ProjectId = projectId,
            IssueIndex = issueIndex
        };
        await Mediator.Send(command);
        return NoContent();
    }
}