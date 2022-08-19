using System.Xml.Xsl;
using AutoMapper;
using BLL.Abstraction;
using BLL.DTOs;
using DAL;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BLL.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;

    public RoomRepository(DataContext context, IMapper mapper, IConfiguration config)
    {
        _context = context;
        _mapper = mapper;
        _config = config;
    }

    public async Task<RoomReadDto> GetMessages(int roomId)
    {
        var room = await _context.Rooms
            .Include(x => x.Messages)
            .FirstOrDefaultAsync(x => x.Id == roomId);

        return _mapper.Map<RoomReadDto>(room);
    }

    public async Task<int> SendMessage(int userId, MessageDto messageDto)
    {

        var user = await _context.Users
            .Include(x => x.Messages)
            .FirstOrDefaultAsync(x => x.Id == userId);

        // if (user == null)
        //     throw new NotFoundException(nameof(User), userId);

        var message = _mapper.Map<Message>(messageDto);

        user.Messages.Add(message);

        await _context.SaveChangesAsync();

        return userId;
    }

    public async Task<int> DeleteMessage(int messageId)
    {
        var message = await _context.Messages
            .FirstOrDefaultAsync(x => x.Id == messageId);

        _context.Messages.Remove(message);

        await _context.SaveChangesAsync();

        return messageId;
    }

    public async Task<int> EditMessage(int messageId, MessageDto messageDto)
    {

        var message = _context.Messages.Find(messageId);
        // var user = await _context.Users
        //     .Include(x => x.Messages)
        //     .FirstOrDefaultAsync(x => x.Id == userId);

        _mapper.Map(messageDto, message);

        _context.Messages.Update(message);

        await _context.SaveChangesAsync();

        return messageId;
    }
}
    