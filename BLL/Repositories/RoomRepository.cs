using AutoMapper;
using BLL.Abstraction;
using BLL.DTOs;
using BLL.Validations;
using DAL;
using Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BLL.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<MessageDto> _messageValidator;

    public RoomRepository(DataContext context, IMapper mapper, 
        IValidator<MessageDto> messageValidator)
    {
        _context = context;
        _mapper = mapper;
        _messageValidator = messageValidator;
    }

    //Get all messages in a room
    public async Task<RoomReadDto> GetMessages(int roomId)
    {
        var room = await _context.Rooms
            .Include(x => x.Messages)
            .FirstOrDefaultAsync(x => x.Id == roomId);

        return _mapper.Map<RoomReadDto>(room);
    }
    
    //Send message to room
    public async Task<int> SendMessage(MessageDto messageDto)
    {
        //Validation
        ValidationResult result = await _messageValidator.ValidateAsync(messageDto);

        if (!result.IsValid)
            throw new ValidationException("Fields can not be empty or null");
        
        
        var user = await _context.Users
        .Include(x => x.Messages)
        .FirstOrDefaultAsync(x => x.Id == messageDto.UserId);
        
        var message = _mapper.Map<Message>(messageDto);
        user.Messages.Add(message);
        await _context.SaveChangesAsync();
        
        return messageDto.UserId;
    }

    //Delete message
    public async Task<int> DeleteMessage(int messageId)
    {
        var message = await _context.Messages
            .FirstOrDefaultAsync(x => x.Id == messageId);

        _context.Messages.Remove(message);
        await _context.SaveChangesAsync();

        return messageId;
    }
    
    //Edit message
    public async Task<int> EditMessage(int messageId, MessageDto messageDto)
    {
        //Validation
        ValidationResult result = await _messageValidator.ValidateAsync(messageDto);

        if (!result.IsValid)
            throw new ValidationException("Fields can not be empty or null");

        
        var message = await _context.Messages.FirstAsync(x => x.Id == messageId);
        // var user = await _context.Users
        //     .Include(x => x.Messages)
        //     .FirstOrDefaultAsync(x => x.Id == userId);

        message.Content = messageDto.Content;
        var date = message.Date;
        message.Date = date;
        _context.Messages.Update(message);
        await _context.SaveChangesAsync();

        return messageId;
    }

    //Get all rooms
    public async Task<IEnumerable<RoomDto>> GetRooms()
    {
        var rooms = await _context.Rooms
            .Include(x => x.Participations)
            .ToListAsync();
    
        return _mapper.Map<IEnumerable<RoomDto>>(rooms);
    }
}
    