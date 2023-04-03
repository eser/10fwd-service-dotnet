public record User
{
    public required Guid Id { get; set; }
    public required string Username { get; set; }
    public required string Fullname { get; set; }
}
