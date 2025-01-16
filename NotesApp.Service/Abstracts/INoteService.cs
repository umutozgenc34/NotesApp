using NotesApp.Model.Dtos;

namespace NotesApp.Service.Abstracts;

public interface INoteService
{
    Task<List<NoteDto>> GetAllNotesAsync();
    Task<NoteDto?> GetNoteByIdAsync(int id);
    Task<NoteDto> AddNoteAsync(CreateNoteRequest noteDto);
    Task UpdateNoteAsync(UpdateNoteRequest request);
    Task DeleteNoteAsync(int id);
}
