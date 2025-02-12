using NoteApi.Entities;

namespace NoteApi.Repositories;

public interface INoteRepository
{
    Task<(IEnumerable<Note> Notes, int TotalCount)> GetAllNotesAsync(int page, int pageSize);
    Task<Note?> GetNoteByIdAsync(int id);
    Task AddNoteAsync(Note note);
    Task UpdateNoteAsync(Note note);
    Task DeleteNoteAsync(int id);
    Task<IEnumerable<Note>> SearchNotesAsync(string searchTerm);
}