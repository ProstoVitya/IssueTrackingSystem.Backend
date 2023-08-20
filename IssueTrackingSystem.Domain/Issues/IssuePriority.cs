namespace IssueTrackingSystem.Domain.Issues;

public class IssuePriority
{
    public int Id { get; set; }
    public string Name { get; set; }
    private int Color { get; set; }
}