
namespace IssueTrackingSystem.Persistence;

public class DbInitializer
{
    public static void Initialize(IssueDbContext issueDbIssueContext)
    {
        //TODO: убрать
        issueDbIssueContext.Database.EnsureDeleted();
        
        issueDbIssueContext.Database.EnsureCreated();
    }
}