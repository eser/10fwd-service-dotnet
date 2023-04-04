public record Profile
{
  public required Guid Id { get; set; }
  public required ProfileType Type { get; set; }
  public required string Slug { get; set; }
  public required string Title { get; set; }
  public required string Description { get; set; }
  public required ICollection<ProfilePage> Pages { get; set; }
  public required ICollection<ProfileLink> Links { get; set; }
  public ICollection<ProfileMembership> Memberships { get; } = new List<ProfileMembership>();
}
