namespace BLL.DTOs;

public class MessageDto
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime? Date { get; set; }
    public int UserId { get; set; }
    public int RoomId { get; set; }
}