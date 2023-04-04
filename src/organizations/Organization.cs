public record Organization
{
  public required Guid Id { get; set; }
  public required OrganizationType Type { get; set; }
  public required string Slug { get; set; }
  public required string Name { get; set; }
  public required string Description { get; set; }
  public ICollection<OrganizationMembership> Memberships { get; } = new List<OrganizationMembership>();
}
