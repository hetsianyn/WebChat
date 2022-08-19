namespace Domain.Models;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Type { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<Message> Messages { get; set; }
}