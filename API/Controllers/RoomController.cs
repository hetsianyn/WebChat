using AutoMapper;
using BLL.Abstraction;
using BLL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public RoomController(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetRoomMessages(int id)
    {
        var messages = await _roomRepository.GetMessages(id);

        return Ok(messages);
    }
    
    [HttpPut("{id}/message")]
    public async Task<ActionResult> SendMessage(int id, 
        [FromForm] MessageDto messageDto)
    {
        var response = await _roomRepository.SendMessage(id, messageDto);

        return StatusCode(201, response);
    }

    [HttpDelete("/message/{id}")]
    public async Task<ActionResult> DeleteMessage(int id)
    {
        var response = await _roomRepository.DeleteMessage(id);

        return StatusCode(201, response);
    }
    
    [HttpPut("/message/edit/{id}")]
    public async Task<ActionResult> UpdateMessage(int id, MessageDto messageDto)
    {
        var response = await _roomRepository.EditMessage(id, messageDto);

        return StatusCode(201, response);
    }
}