public record Profile
{
  public required Guid Id { get; set; }
  public required ProfileOwner Owner { get; set; }
  public required Guid OwnerId { get; set; }
  public required string Slug { get; set; }
  public required string Title { get; set; }
  public required string Description { get; set; }
  public required ICollection<ProfilePage> Pages { get; set; }
}
