public record ProfileLink
{
  public required Guid Id { get; set; }
  public required string Title { get; set; }
  public required string Description { get; set; }
  public required string Uri { get; set; }
}
