public record ProfilePage
{
  public required Guid Id { get; set; }
  public required string Slug { get; set; }
  public required string Title { get; set; }
  public required string Description { get; set; }
  public required string Content { get; set; }
}
