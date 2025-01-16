using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotesApp.Model.Dtos;
using NotesApp.Model.Entities;
using NotesApp.Repository.Abstracts;
using NotesApp.Service.Abstracts;

namespace NotesApp.Service.Concretes;

public class NoteService(INoteRepository noteRepository,IMapper mapper) : INoteService
{
    public async Task<NoteDto> AddNoteAsync(CreateNoteRequest noteDto)
    {
        var note = mapper.Map<Note>(noteDto); 
        await noteRepository.CreateAsync(note);
        var noteAsDto = mapper.Map<NoteDto>(note);
        return noteAsDto;
    }

    public async Task DeleteNoteAsync(int id)
    {
        var note = await noteRepository.GetByIdAsync(id) ?? throw new Exception("note bulunamadı");
        await noteRepository.Delete(id);
    }

    public async Task<List<NoteDto>> GetAllNotesAsync()
    {
        var notes = await noteRepository.GetAllAsync();
        var notesAsDto = mapper.Map<List<NoteDto>>(notes);
        return notesAsDto;
    }

    public async Task<NoteDto?> GetNoteByIdAsync(int id)
    {
        var note = await noteRepository.GetByIdAsync(id);
        var noteAsDto = mapper.Map<NoteDto> (note);
        return noteAsDto;
    }

    public async Task UpdateNoteAsync(UpdateNoteRequest request)
    {
        var note = await noteRepository.GetByIdAsync(request.Id);
        if (note == null)
        {
            throw new Exception("Note bulunamadı");
        }

        note.Title = request.Title;
        note.Content = request.Content;

        await noteRepository.Update(note);
    }
}
