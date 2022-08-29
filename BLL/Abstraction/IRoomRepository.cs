using BLL.DTOs;

namespace BLL.Abstraction;

public interface IRoomRepository
{
    Task<RoomReadDto> GetMessages(int roomId);
    Task<int> DeleteMessage(int messageId);
    Task<int> EditMessage(int messageId, MessageDto messageDto);
    Task<IEnumerable<RoomDto>> GetRooms();
    Task<int> SendMessage(MessageDto messageDto);
}