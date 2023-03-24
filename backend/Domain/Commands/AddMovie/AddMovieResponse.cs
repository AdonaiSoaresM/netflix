namespace Domain.Commands.AddMovie
{
    public class AddMovieResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public AddMovieResponse(Guid id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}