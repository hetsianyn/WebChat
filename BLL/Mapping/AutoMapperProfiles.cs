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
        CreateMap<Room, RoomDto>()
            .ForMember(dest => dest.ParticipantsNum, 
                opt => opt.MapFrom(user => user.Participations
                    .Count(x => x.RoomId == user.Id)));
    }
}