using NoteApi.Entities;
using NoteApi.Repositories;

namespace NoteApi.Endpoints
{
    public static class NoteEndpoints
    {
        const string GetNoteEndpointName = "GetNoteV1";

        public static RouteGroupBuilder MapNotesEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("v1/notes");

            group.MapPost("/", async (INoteRepository repository, Note note) =>
            {
                await repository.AddNoteAsync(note);

                return Results.CreatedAtRoute(GetNoteEndpointName, new { id = note.Id }, note);
            });

            group.MapGet("/", async (INoteRepository repository, int page = 1, int pageSize = 10) =>
            {
                var (notes, totalCount) = await repository.GetAllNotesAsync(page, pageSize);

                return Results.Ok(new { Notes = notes, TotalCount = totalCount });
            });

            group.MapGet("/{id}", async (INoteRepository repository, int id) =>
            {
                var note = await repository.GetNoteByIdAsync(id);

                return note is not null ? Results.Ok(note) : Results.NotFound();
            }).WithName(GetNoteEndpointName);

            group.MapPut("/{id}", async (INoteRepository repository, int id, Note UpdatedNote) =>
            {
                var existingNote = await repository.GetNoteByIdAsync(id);
                if (existingNote is null) {
                    return Results.NotFound();
                }

                UpdatedNote.Id = id;
                await repository.UpdateNoteAsync(UpdatedNote);

                return Results.NoContent();
            });

            group.MapDelete("/{id}", async (INoteRepository repository, int id) =>
            {
                var existingNote = await repository.GetNoteByIdAsync(id);
                if (existingNote is null) {
                    return Results.NotFound();
                }

                await repository.DeleteNoteAsync(id);
                
                return Results.NoContent();
            });

            group.MapGet("/search", async (INoteRepository repository, string searchTerm) => {
                var notes = await repository.SearchNotesAsync(searchTerm);

                return Results.Ok(notes);
            });

            return group;
        }
    }
}