using IssueTrackingSystem.Domain.Issues;
using IssueTrackingSystem.Domain.Users;

namespace IssueTrackingSystem.Domain;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ISet<User> Collaborators { get; set; }
    public ISet<Issue> Issues { get; set; }
}