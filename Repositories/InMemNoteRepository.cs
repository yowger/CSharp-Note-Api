using Microsoft.AspNetCore.Mvc;
using NoteApi.Entities;

namespace NoteApi.Repositories;

public class InMemNoteRepository : INoteRepository
{
    // private readonly List<Note> _notes = new();
    // private int _nextId = 1;
    
     private readonly List<Note> _notes = new()
    {
        new Note
        {
            Id = 1,
            UserId = "user_001",
            Title = "Meeting Notes",
            Content = "Discuss project roadmap and milestones.",
            IsArchived = false,
            Tags = new List<string> { "work", "meeting" }
        },
        new Note
        {
            Id = 2,
            UserId = "user_002",
            Title = "Grocery List",
            Content = "Milk, eggs, bread, and coffee.",
            IsArchived = false,
            Tags = new List<string> { "shopping", "personal" }
        },
        new Note
        {
            Id = 3,
            UserId = "user_003",
            Title = "Workout Plan",
            Content = "Monday - Chest & Triceps, Wednesday - Back & Biceps.",
            IsArchived = false,
            Tags = new List<string> { "fitness", "health" }
        },
        new Note
        {
            Id = 4,
            UserId = "user_004",
            Title = "Vacation Ideas",
            Content = "Visit Japan, explore Kyoto, try sushi.",
            IsArchived = false,
            Tags = new List<string> { "travel", "bucket list" }
        }
    };
    private int _nextId = 5;

    public Task AddNoteAsync(Note note)
    {
        note.Id = _nextId++;
        note.CreatedAt = DateTime.Now;
        note.UpdatedAt = DateTime.Now;
        _notes.Add(note);

        return Task.CompletedTask;
    }

    public Task<(IEnumerable<Note> Notes, int TotalCount)> GetAllNotesAsync(int page, int pageSize)
    {
        var totalCount = _notes.Count();
        var notes = _notes
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return Task.FromResult((notes as IEnumerable<Note>, totalCount));
    }

    public Task<Note?> GetNoteByIdAsync(int id)
    {
        var note = _notes.FirstOrDefault(n => n.Id == id);

        return Task.FromResult(note);
    }

    public Task UpdateNoteAsync(Note note)
    {
        var existingNote = _notes.FirstOrDefault(n => n.Id == note.Id);

        if (existingNote != null)
        {
            existingNote.Title = note.Title;
            existingNote.Content = note.Content;
            existingNote.UpdatedAt = DateTime.Now;
            existingNote.IsArchived = note.IsArchived;
            existingNote.Tags = note.Tags;
        }

        return Task.CompletedTask;
    }

    public Task DeleteNoteAsync(int id)
    {
        var note = _notes.FirstOrDefault(note => note.Id == id);
        if (note != null)
        {
            _notes.Remove(note);
        }

        return Task.CompletedTask;
    }

    // TODO: search by tags, date 
    // TODO: pagination
    public Task<IEnumerable<Note>> SearchNotesAsync(string searchTerm)
    {
        var notes = _notes
            .Where(n => n.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || 
                n.Content.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .ToList();

        return Task.FromResult(notes as IEnumerable<Note>);
    }
}