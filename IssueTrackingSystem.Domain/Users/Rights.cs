using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IssueTrackingSystem.Domain.Users;

public class Rights
{
    private Rights() { }

    private Rights(RightsEnum @enum)
    {
        Id = (int)@enum;
        Name = @enum.ToString();
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Name { get; set; }

    public static implicit operator Rights(RightsEnum @enum) => new Rights(@enum);
    public static implicit operator RightsEnum(Rights rights) => (RightsEnum)rights.Id;
}