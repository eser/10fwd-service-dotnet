// [PrimaryKey(nameof(Organization), nameof(User))]
public record OrganizationMembership
{
  public required Guid Id { get; set; }
  public required Organization Organization { get; set; }
  public required User User { get; set; }
  public required OrganizationMembershipRole Role { get; set; }
}
