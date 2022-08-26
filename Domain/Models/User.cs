using System.Diagnostics;

namespace Domain.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Photo { get; set; }
    public ICollection<Message> Messages { get; set; }
    public ICollection<Participation> Participations { get; set; }
}