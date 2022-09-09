using BLL.DTOs;

namespace BLL.Abstraction;

public interface IRoomRepository
{
    Task<RoomReadDto> GetMessages(int roomId);
    Task<IEnumerable<RoomDto>> GetRooms();
    Task<int> SendMessage(MessageDto messageDto);
    Task<int> EditMessage(int messageId, MessageDto messageDto);
    Task<int> DeleteMessage(int messageId);
}