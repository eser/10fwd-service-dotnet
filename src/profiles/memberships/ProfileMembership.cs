// [PrimaryKey(nameof(Profile), nameof(User))]
public record ProfileMembership
{
  public required Guid Id { get; set; }
  public required Profile Profile { get; set; }
  public required User User { get; set; }
  public required ProfileMembershipRole Role { get; set; }
}
