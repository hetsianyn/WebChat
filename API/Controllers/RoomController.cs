using AutoMapper;
using BLL.Abstraction;
using BLL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api")]
public class RoomController : ControllerBase
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public RoomController(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }
    
    //Get room details by id(with messages)
    [HttpGet("rooms/{id}")]
    public async Task<ActionResult> GetRoomMessages(int id)
    {
        var messages = await _roomRepository.GetMessages(id);

        return Ok(messages);
    }
    
    //Create message
    [HttpPost("message")]
    public async Task<ActionResult> SendMessage(
        [FromBody] MessageDto messageDto)
    {
        var response = await _roomRepository.SendMessage(messageDto);

        return StatusCode(201, response);
    }

    //Delete message, return message id response
    [HttpDelete("message/{id}")]
    public async Task<ActionResult> DeleteMessage(int id)
    {
        var response = await _roomRepository.DeleteMessage(id);

        return StatusCode(201, response);
    }
    
    //Edit message by id
    [HttpPut("/message/edit/{id}")]
    public async Task<ActionResult> UpdateMessage(int id, MessageDto messageDto)
    {
        var response = await _roomRepository.EditMessage(id, messageDto);

        return StatusCode(201, response);
    }
    
    //Get all rooms
    [HttpGet("rooms")]
    public async Task<ActionResult> GetAllRooms()
    {
        var rooms = await _roomRepository.GetRooms();
        return Ok(rooms);
    }
}