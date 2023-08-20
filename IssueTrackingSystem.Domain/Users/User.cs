namespace IssueTrackingSystem.Domain.Users;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    public DateTime RegistrationDate { get; set; }
    public ISet<Rights> Rights { get; set; }
    public ISet<Project> RelatedProjects { get; set; }
}