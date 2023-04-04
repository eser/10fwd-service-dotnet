public record User
{
  public required Guid Id { get; set; }
  public required string Username { get; set; }
  public required string Email { get; set; }
  public required string Password { get; set; }
  public required string Fullname { get; set; }
  public required string Bio { get; set; }
  public required string ProfilePictureUri { get; set; }
  public required string WebSiteUri { get; set; }
  public required string GitHubHandle { get; set; }
  public required string TwitterHandle { get; set; }
  public ICollection<OrganizationMembership> OrganizationMemberships { get; } = new List<OrganizationMembership>();
}
