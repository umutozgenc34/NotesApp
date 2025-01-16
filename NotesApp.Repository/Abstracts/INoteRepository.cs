using NotesApp.Model.Entities;
using NotesApp.Repository.Context;

namespace NotesApp.Repository.Abstracts;

public interface INoteRepository
{
    Task<List<Note>> GetAllAsync();
    Task<Note?> GetByIdAsync(int id);
    Task<Note> CreateAsync(Note note);
    Task Delete(int id);
    Task Update(Note note);
}
