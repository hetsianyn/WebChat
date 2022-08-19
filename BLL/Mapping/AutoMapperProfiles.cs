using AutoMapper;
using BLL.DTOs;
using Domain.Models;

namespace BLL.Mapping;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Message, MessageDto>();
        CreateMap<Room, RoomReadDto>();
        CreateMap<MessageDto, Message>();
    }
}