namespace Domain.Models;

public class Message
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
    public int RoomId { get; set; }
    public User User { get; set; }
    public Room Room { get; set; }
    
}