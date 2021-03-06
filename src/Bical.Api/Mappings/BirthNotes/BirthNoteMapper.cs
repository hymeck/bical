using AutoMapper;
using Bical.Api.Cqrs.Commands.BirthNotes;
using Bical.Api.Entities;
using Bical.Api.Responses;

namespace Bical.Api.Mappings.BirthNotes
{
    public class CreateCommandMapper : Profile
    {
        public CreateCommandMapper()
        {
            CreateMap<CreateBirthNoteCommand, BirthNote>();
        }
    }

    public class DtoResponseMapper : Profile
    {
        public DtoResponseMapper()
        {
            CreateMap<BirthNote, BirthNoteDtoResponse>()
                .ForMember(d => d.BirthNoteId, map => map.MapFrom(s => s.Id));
        }
    }
}