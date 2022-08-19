namespace BLL.DTOs;

public class RoomReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Type { get; set; }
    public ICollection<MessageDto> Messages { get; set; }
}