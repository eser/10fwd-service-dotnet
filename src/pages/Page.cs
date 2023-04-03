public record Page
{
  public required Guid Id { get; set; }
  public required PageOwner Owner { get; set; }
  public required Guid OwnerId { get; set; }
  public required string Slug { get; set; }
  public required string Title { get; set; }
  public required string Description { get; set; }
  public required string Content { get; set; }
}
