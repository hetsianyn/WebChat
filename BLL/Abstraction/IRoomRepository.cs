using BLL.DTOs;

namespace BLL.Abstraction;

public interface IRoomRepository
{
    Task<RoomReadDto> GetMessages(int roomId);
    Task<int> SendMessage(int userId, MessageDto messageDto);
    Task<int> DeleteMessage(int messageId);
    Task<int> EditMessage(int messageId, MessageDto messageDto);
}