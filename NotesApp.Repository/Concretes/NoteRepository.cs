using Microsoft.EntityFrameworkCore;
using NotesApp.Model.Entities;
using NotesApp.Repository.Abstracts;
using NotesApp.Repository.Context;

namespace NotesApp.Repository.Concretes;

public class NoteRepository(AppDbContext context) : INoteRepository
{
    public async Task<Note> CreateAsync(Note note)
    {
        note.Created = DateTime.Now;
        await context.AddAsync(note);
        await context.SaveChangesAsync();
        return note;
    }

    public  async Task Delete(int id)
    {
        var note = context.Notes.FirstOrDefault(x => x.Id == id);
        context.Notes.Remove(note);
        await context.SaveChangesAsync();
    }

    public async Task<List<Note>> GetAllAsync() => await context.Notes.ToListAsync();


    public async Task<Note?> GetByIdAsync(int id) => await context.Notes.FindAsync(id);
    

    public async Task Update(Note note)
    {
        context.Notes.Update(note);
        await context.SaveChangesAsync();
      
    }
}
