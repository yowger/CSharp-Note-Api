namespace NoteApi.Endpoints
{
    public static class NoteEndpoints
    {
        public static RouteGroupBuilder MapNotesEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("v1/notes");

            group.MapGet("/", () => "GET");

            group.MapPost("/", () => "POST");

            group.MapPut("/", () => "PUT");

            group.MapDelete("/", () => "DELETE");

            return group;
        }
    }
}