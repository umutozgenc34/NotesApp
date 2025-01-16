using Microsoft.EntityFrameworkCore;
using NotesApp.Model.Entities;
using System.Reflection;

namespace NotesApp.Repository.Context;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
