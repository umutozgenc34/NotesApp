using AutoMapper;
using NotesApp.Model.Dtos;
using NotesApp.Model.Entities;

namespace NotesApp.Service.Profiles;

public class NoteMappingProfile : Profile
{
    public NoteMappingProfile()
    {
        CreateMap<CreateNoteRequest, Note>();
        CreateMap<Note, NoteDto>().ReverseMap();
    }
}
